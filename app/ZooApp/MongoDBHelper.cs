using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.Data;

namespace ZooApp
{
    public static class MongoDBHelper
    {
        private static IMongoDatabase database;

        /**<summary>
         * Collection names for the DB app.
         * </summary>
         */
        public enum DBCollection
        {
            Care = 0,
            Feed = 1,
            Staff = 2,
            Zone = 3,
            SpeciesGroup = 4
        }

        //All the names of the collection in the app DB. Each index has a matching enum in DBCollection.
        private static readonly string[] DBCollections = new string[5]{
            "Care",
            "Feed",
            "Staff",
            "Zone",
            "speciesGroup"
            //"SpeciesGroup"
        };

        private static string getCollectionName(DBCollection collectionName)
        {
            return DBCollections[(int)collectionName];
        }

		//TODO: Add your own connection string
        private static string connectionString = "";

        public static void Initialize(string dbName = "Zoo")
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(dbName);
        }

        public static IMongoCollection<BsonDocument> GetCollection(DBCollection collectionName)
        {
            return database.GetCollection<BsonDocument>(getCollectionName(collectionName));
        }

        public static IMongoDatabase getDatabase()
        {
            return database;
        }


        public static List<BsonDocument> FindAll(DBCollection collectionName)
        {
            return GetCollection(collectionName).Find(new BsonDocument()).ToList();
        }


        public static void InsertDocument(DBCollection collectionName, BsonDocument document)
        {
            GetCollection(collectionName).InsertOne(document);
        }

        public static List<BsonDocument> AggregateSpeciesAnimals()
        {
            var pipeline = new[]
            {
        new BsonDocument("$unwind", "$species"),
        new BsonDocument("$unwind", "$species.animals"),
        new BsonDocument("$project", new BsonDocument
        {
            { "animal_id", "$species.animals.aid" },
            { "name", "$species.animals.name" },
            { "sex", "$species.animals.sex" },
            { "feedingInterval", "$species.animals.feedingInterval" },
            { "weight", "$species.animals.weight" },
            { "originCountry", "$species.animals.originCountry" },
            { "dob", "$species.animals.dob" },
            { "speciesName", "$species.latinName" },
            { "speciesCommon", "$species.commonName" },
            { "requiredBiome", "$species.requiredBiome" },
            { "groupCommon", "$commonName" },
        })
    };

            return GetCollection(DBCollection.SpeciesGroup)
                .Aggregate<BsonDocument>(pipeline)
                .ToList();
        }

        public static (string enclosureName, string zoneName) GetEnclosureZoneByAnimalId(int aid)
        {
            var pipeline = new[]
            {
        new BsonDocument("$match", new BsonDocument("enclosures.animal.aid", aid)),
        new BsonDocument("$unwind", "$enclosures"),
        new BsonDocument("$unwind", "$enclosures.animal"),
        new BsonDocument("$match", new BsonDocument("enclosures.animal.aid", aid)),
        new BsonDocument("$project", new BsonDocument
        {
            { "zoneName", "$name" },
            { "enclosureName", "$enclosures.name" }
        })
    };

            var result = GetCollection(DBCollection.Zone)
                .Aggregate<BsonDocument>(pipeline)
                .FirstOrDefault();

            if (result != null)
            {
                return (result["enclosureName"].AsString, result["zoneName"].AsString);
            }

            return ("Unknown", "Unknown");
        }

        public static List<string> GetZookeeperNamesByGroup(string groupLatinName)
        {
            var allStaff = FindAll(DBCollection.Staff);

            var keeperIds = allStaff
                .Where(s => s.Contains("oversees") &&
                            s["oversees"].AsBsonArray
                                .Any(o => o["latinName"].AsString == groupLatinName))
                .Select(s => s["sid"].AsInt32)
                .Distinct();

            return GetStaffNamesByIds(keeperIds);
        }

        public static List<string> GetVetNamesByAnimalId(int aid)
        {
            var cares = FindAll(DBCollection.Care)
                .Where(c => c["animalID"].AsInt32 == aid);

            var vetIds = cares
                .Select(c => c["staffID"].AsInt32)
                .Distinct();

            return GetStaffNamesByIds(vetIds);
        }
        public static List<string> GetStaffNamesByIds(IEnumerable<int> staffIds)
        {
            var allStaff = FindAll(DBCollection.Staff);

            return allStaff
                .Where(s => staffIds.Contains(s["sid"].AsInt32))
                .Select(s => $"{s["fName"]} {s["lName"]}")
                .Distinct()
                .ToList();
        }
        public static List<(int enclosureID, string enclosureName)> GetEnclosuresFromZoneName(string zoneName)
        {
            var pipeline = new[]
            {
                new BsonDocument("$match",
                new BsonDocument("name", "Africa")),
                new BsonDocument("$unwind",
                new BsonDocument("path", "$enclosures"))
            };

            var results = GetCollection(DBCollection.Zone)
                .Aggregate<BsonDocument>(pipeline)
                .ToList();

            if (results != null)
            {
                List<(int, string)> toReturn = new List<(int, string)>();

                foreach (BsonDocument b in results)
                {
                    BsonElement test = b.GetElement("enclosures");
                    toReturn.Add(((int, string))((b["enclosures.eid"].AsInt32), (b["enclosures.name"].AsString)));
                }

                return toReturn;
            }

            return null;
        }

    }
}

