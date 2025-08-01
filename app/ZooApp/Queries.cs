using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oracle.ManagedDataAccess.Client;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using ZooApp.POCO;
using MongoDB.Bson.Serialization;

namespace ZooApp
{
    /// <summary>
    /// Class to store query strings in one place
    /// </summary>
    internal static class Queries
    {
        private static DBType currentDB;

        /**<summary>
         * The Types of databases that the application can support.
         * </summary>
         */
        public enum DBType
        {
            Oracle = 0,
            Mongo = 1
        }

        /**<summary>Sets the current DBType to the value passed in.
         * </summary>
         * <param name="dbType">The value conresponding with the dbType.</param>
         */
        public static void setDBType(DBType dbType)
        {
                currentDB = dbType;
        }

        /**<summary>
         * Getts the current DBType
         * </summary>
         * <returns> The DBType that the application is currently connected too.</returns>
         */
        public static DBType getDBType()
        {
            return currentDB;
        }

        // Make sure to add the animal ID on to the end of this
        public static String ZookeepersQualifiedForAnimal =
            $"SELECT s.sid, s.lname, s.fname " +
            $"FROM {DatabaseHelper.Table("STAFF")} s, " +
            $"{DatabaseHelper.Table("SPECIESGROUP")} sg, " +
            $"{DatabaseHelper.Table("SPECIES")} sp, " +
            $"{DatabaseHelper.Table("ANIMAL")} a, " +
            $"{DatabaseHelper.Table("OVERSEES")} o " +
            $"WHERE s.sid = o.staffID " +
            $"AND o.sGroupName = sg.latinName " +
            $"AND sp.speciesGroup = sg.latinName " +
            $"AND a.speciesName = sp.latinName";

        // Make sure to add the encloure ID at the end of this
        public static String ZookeepersQualifiedForEnclosure = $@"
            SELECT s.sid, s.lname, s.fname
            FROM {DatabaseHelper.Table("STAFF")} s, {DatabaseHelper.Table("OVERSEES")} o
            WHERE s.sid = o.staffid
            AND o.sgroupname = ALL(
            SELECT distinct sg.latinName
            FROM {DatabaseHelper.Table("SPECIESGROUP")} sg, {DatabaseHelper.Table("SPECIES")} sp, {DatabaseHelper.Table("ANIMAL")} a
            WHERE sp.latinName = a.speciesName
            AND sp.speciesgroup = sg.latinName";

        public static String AnimalsInEnclosure = $@"
            SELECT a.aid, a.name
            FROM {DatabaseHelper.Table("ENCLOSURE")} e
            JOIN {DatabaseHelper.Table("ANIMAL")} a on e.eid = a.enclosureid
        ";

        public static String PossibleEnclosuresForAnimal = $@"
            SELECT e.eid, e.zoneName
            FROM {DatabaseHelper.Table("ANIMAL")} a,
            {DatabaseHelper.Table("ENCLOSURE")} e,
            {DatabaseHelper.Table("SPECIES")} s
            WHERE a.speciesName = s.latinName
            AND s.requiredBiome = e.biome
        ";

        public static String ZookeeperQualifications = $@"
            SELECT sg.commonName
            FROM {DatabaseHelper.Table("OVERSEES")} o, 
            {DatabaseHelper.Table("SPECIESGROUP")} sg
            WHERE o.sGroupName = sg.latinName
        ";

        // Query to load the Animals table
        public static String LoadAnimalsQuery = $@"
                    SELECT 
                        a.aid,
                        a.name,
                        a.sex,
                        a.dob,
                        a.weight,
                        a.feedingInterval,
                        a.originCountry,
                        a.enclosureID,
                        e.biome,
                        e.zoneName,
                        a.speciesName,
                        sg.commonName AS speciesGroup
                    FROM {DatabaseHelper.Table("ANIMAL")} a
                    LEFT JOIN {DatabaseHelper.Table("ENCLOSURE")} e ON a.enclosureID = e.eid
                    LEFT JOIN {DatabaseHelper.Table("SPECIES")} s ON a.speciesName = s.latinName
                    LEFT JOIN {DatabaseHelper.Table("SPECIESGROUP")} sg ON s.speciesGroup = sg.latinName
                    WHERE 1=1";

        // Query to load the Enclosures table
        public static String LoadEnclosuresQuery =
            $"SELECT e.eid, e.biome, e.esize, z.name AS zoneName " +
            $"FROM {DatabaseHelper.Table("ENCLOSURE")} e " +
            $"JOIN {DatabaseHelper.Table("ZONE")} z ON e.zoneName = z.name";

        // Query to load the Staff table
        public static String LoadStaffQuery = $@"
            SELECT
                s.sid,
                s.fName || ' ' || s.lName AS fullName,
                s.dob,
                s.sex,
                s.phNumber,
                s.email,
                s.streetNumber || ' ' || s.streetName || ', ' || s.suburb || ', ' || s.city || ' ' || s.postCode AS address,
                s.clinic,
                CASE
                    WHEN EXISTS (SELECT 1 FROM {DatabaseHelper.Table("FEED")} f WHERE f.staffID = s.sid) THEN 'Zookeeper'
                    WHEN EXISTS (SELECT 1 FROM {DatabaseHelper.Table("CARE")} c WHERE c.staffID = s.sid) THEN 'Vet'
                    ELSE 'Unknown'
                END AS role
            FROM {DatabaseHelper.Table("STAFF")} s
            WHERE 1=1
            ";

        // Query to load the Feeding and Care tables (same time)
        public static String LoadFeedingAndCareQuery = $@"
        SELECT 
            F.staffID,
            S.fName || ' ' || S.lName AS StaffName,
            F.animalID,
            A.name AS AnimalName,
            F.dateTime,
            'Feeding' AS Type,
            F.foodType AS FoodType,
            TO_CHAR(F.amount) AS FoodAmount,
            NULL AS CareType,
            NULL AS VetNotes
        FROM {DatabaseHelper.Table("FEED")} F
        JOIN {DatabaseHelper.Table("STAFF")} S ON F.staffID = S.sid
        JOIN {DatabaseHelper.Table("ANIMAL")} A ON F.animalID = A.aid

        UNION ALL

        SELECT 
            C.staffID,
            S.fName || ' ' || S.lName AS StaffName,
            C.animalID,
            A.name AS AnimalName,
            C.dateTime,
            'Care' AS Type,
            NULL AS FoodType,
            NULL AS FoodAmount,
            C.care AS CareType,
            C.notes AS VetNotes
        FROM {DatabaseHelper.Table("CARE")} C
        JOIN {DatabaseHelper.Table("STAFF")} S ON C.staffID = S.sid
        JOIN {DatabaseHelper.Table("ANIMAL")} A ON C.animalID = A.aid

        ORDER BY dateTime DESC";
        //Line is to make sure i can find my queries 
        //---------------------------------------------------------------------------//
        //Animal

        /// <summary>
        /// Loads all animals for selection (dropdown combo).
        /// </summary>
        public static string SelectAllAnimals = $@"
        SELECT aid, name 
        FROM {DatabaseHelper.Table("Animal")} 
        ORDER BY aid";

        /// <summary>
        /// Inserts a new animal with full details.
        /// </summary>
        public static string InsertAnimal = $@"
        INSERT INTO {DatabaseHelper.Table("Animal")} 
        (aid, name, dob, weight, originCountry, feedingInterval, sex, enclosureID, speciesName) 
        VALUES (:aid, :name, :dob, :weight, :origin, :feeding, :sex, :enclosure, :species)";

        /// <summary>
        /// Updates existing animal details by ID.
        /// </summary>
        public static string UpdateAnimal = $@"
        UPDATE {DatabaseHelper.Table("Animal")} 
        SET name = :name, dob = :dob, weight = :weight, originCountry = :origin, 
            feedingInterval = :feeding, sex = :sex, enclosureID = :enclosure, speciesName = :species 
        WHERE aid = :aid";

        /// <summary>
        /// Deletes an animal by ID.
        /// </summary>
        public static string DeleteAnimal = $@"
        DELETE FROM {DatabaseHelper.Table("Animal")} 
        WHERE aid = :aid";

        /// <summary>
        /// Gets full details for an animal by ID (including species and group join).
        /// </summary>
        public static string SelectAnimalById = $@"
        SELECT a.*, s.commonName AS speciesCommon, s.requiredBiome, s.speciesGroup,
               sg.commonName AS groupCommon
        FROM {DatabaseHelper.Table("Animal")} a
        JOIN {DatabaseHelper.Table("Species")} s ON a.speciesName = s.latinName
        LEFT JOIN {DatabaseHelper.Table("SpeciesGroup")} sg ON s.speciesGroup = sg.latinName
        WHERE a.aid = :aid";

        //----------------------------------------------
        //Species


        // Get all species latin names only
        public static string SelectAllSpecies = $@"
        SELECT latinName 
        FROM {DatabaseHelper.Table("Species")} 
        ORDER BY latinName";

        // Get full species details by latin name
        public static string SelectSpeciesByLatinName = $@"
        SELECT * 
        FROM {DatabaseHelper.Table("Species")} 
        WHERE latinName = :name";

        // Insert a new species record
        public static string InsertSpecies = $@"
        INSERT INTO {DatabaseHelper.Table("Species")} 
        (latinName, commonName, requiredBiome, speciesGroup) 
        VALUES (:latin, :common, :biome, :group)";

        // Update an existing species record by latin name
        public static string UpdateSpecies = $@"
        UPDATE {DatabaseHelper.Table("Species")} 
        SET commonName = :common, 
            requiredBiome = :biome, 
            speciesGroup = :group 
        WHERE latinName = :latin";

        // Delete a species record by latin name
        public static string DeleteSpecies = $@"
        DELETE FROM {DatabaseHelper.Table("Species")} 
        WHERE latinName = :latin";

        // Get all species group latin names
        public static string SelectAllSpeciesGroups =>
            $"SELECT commonName, latinName FROM {DatabaseHelper.Table("SpeciesGroup")} ORDER BY commonName";


        // Get full species group details by latin name
        public static string SelectSpeciesGroupByLatinName = $@"
        SELECT * 
        FROM {DatabaseHelper.Table("SpeciesGroup")} 
        WHERE latinName = :name";

        // Insert a new species group record
        public static string InsertSpeciesGroup = $@"
        INSERT INTO {DatabaseHelper.Table("SpeciesGroup")} 
        (latinName, commonName) 
        VALUES (:latin, :common)";

        // Update an existing species group record by latin name
        public static string UpdateSpeciesGroup = $@"
        UPDATE {DatabaseHelper.Table("SpeciesGroup")} 
        SET commonName = :common 
        WHERE latinName = :latin";

        // Delete a species group record by latin name
        public static string DeleteSpeciesGroup = $@"
        DELETE FROM {DatabaseHelper.Table("SpeciesGroup")} 
        WHERE latinName = :latin";

        // === Staff Queries ===

        /// <summary>
        /// Selects all staff (SID, first name, last name) for dropdown use.
        /// </summary>
        public static string SelectAllStaffBasic = $@"
        SELECT sid, fName, lName 
        FROM {DatabaseHelper.Table("Staff")} 
        ORDER BY sid";

        /// <summary>
        /// Gets the next available staff ID.
        /// </summary>
        public static string GetNextStaffId = $@"
        SELECT NVL(MAX(sid), 0) + 1 
        FROM {DatabaseHelper.Table("Staff")}";

        /// <summary>
        /// Selects a staff record by ID.
        /// </summary>
        public static string SelectStaffById = $@"
        SELECT * 
        FROM {DatabaseHelper.Table("Staff")} 
        WHERE sid = :sid";

        /// <summary>
        /// Inserts a new staff record.
        /// </summary>
        public static string InsertStaff = $@"
        INSERT INTO {DatabaseHelper.Table("Staff")}
        (sid, fName, lName, dob, phNumber, email, streetNumber, streetName, suburb, city, postCode, sex)
        VALUES
        (:sid, :fName, :lName, :dob, :phNumber, :email, :streetNumber, :streetName, :suburb, :city, :postCode, :sex)";

        /// <summary>
        /// Updates an existing staff record.
        /// </summary>
        public static string UpdateStaff = $@"
        UPDATE {DatabaseHelper.Table("Staff")} SET 
            fName = :fName,
            lName = :lName,
            dob = :dob,
            phNumber = :phNumber,
            email = :email,
            streetNumber = :streetNumber,
            streetName = :streetName,
            suburb = :suburb,
            city = :city,
            postCode = :postCode,
            sex = :sex
        WHERE sid = :sid";

        /// <summary>
        /// Deletes a staff record by SID.
        /// </summary>
        public static string DeleteStaff = $@"
        DELETE FROM {DatabaseHelper.Table("Staff")} 
        WHERE sid = :sid";

        //--------------------------------
        //Care

        /// <summary>
        /// Checks if a vet already has a care record.
        /// </summary>
        public static string CheckVetCareExists = $@"
        SELECT 1 
        FROM {DatabaseHelper.Table("Care")} 
        WHERE staffID = :sid 
        FETCH FIRST 1 ROWS ONLY";

        /// <summary>
        /// Inserts a dummy care entry for a new vet.
        /// </summary>
        public static string InsertDummyCare = $@"
        INSERT INTO {DatabaseHelper.Table("Care")}
        (staffID, animalID, dateTime, care, notes)
        VALUES (:sid, :aid, :dt, :care, :notes)";

        /// <summary>
        /// Deletes all care records for a staff ID.
        /// </summary>
        public static string DeleteCareByStaff = $@"
        DELETE FROM {DatabaseHelper.Table("Care")} 
        WHERE staffID = :sid";

        //---------------------------------------------
        //Oversees

        /// <summary>
        /// Checks if a zookeeper is already linked to a species group.
        /// </summary>
        public static string CheckOverseesExists = $@"
        SELECT 1 
        FROM {DatabaseHelper.Table("Oversees")} 
        WHERE staffID = :sid 
        FETCH FIRST 1 ROWS ONLY";

        /// <summary>
        /// Inserts a dummy oversees entry for a zookeeper.
        /// </summary>
        public static string InsertDummyOversees = $@"
        INSERT INTO {DatabaseHelper.Table("Oversees")}
        (sGroupName, staffID)
        VALUES (:grp, :sid)";

        /// <summary>
        /// Deletes all oversees entries for a staff ID.
        /// </summary>
        public static string DeleteOverseesByStaff = $@"
        DELETE FROM {DatabaseHelper.Table("Oversees")} 
        WHERE staffID = :sid";

        //-------------------------
        //Feed

        /// <summary>
        /// Deletes all feed records for a staff ID.
        /// </summary>
        public static string DeleteFeedByStaff = $@"
        DELETE FROM {DatabaseHelper.Table("Feed")} 
        WHERE staffID = :sid";

        //------------------------------------------
        //Vet Clinic

        /// <summary>
        /// Selects all Vets (SID and full name) from Staff who appear in Care table, including a given SID fallback.
        /// </summary>
        public static string SelectAllVets = $@"
        SELECT sid, fName || ' ' || lName AS fullName
        FROM {DatabaseHelper.Table("Staff")}
        WHERE sid IN (
            SELECT DISTINCT staffID FROM {DatabaseHelper.Table("Care")}
        ) OR sid = :sid";

        /// <summary>
        /// Gets distinct list of clinic names used in Staff table.
        /// </summary>
        public static string SelectDistinctClinics = $@"
        SELECT DISTINCT clinic 
        FROM {DatabaseHelper.Table("Staff")} 
        WHERE clinic IS NOT NULL 
        ORDER BY clinic";

        /// <summary>
        /// Gets the current clinic assigned to a staff member.
        /// </summary>
        public static string SelectClinicBySid = $@"
        SELECT clinic 
        FROM {DatabaseHelper.Table("Staff")} 
        WHERE sid = :sid";

        /// <summary>
        /// Checks if a clinic already exists in Staff records.
        /// </summary>
        public static string CheckClinicExists = $@"
        SELECT 1 
        FROM {DatabaseHelper.Table("Staff")} 
        WHERE LOWER(clinic) = LOWER(:clinic)";

        /// <summary>
        /// Assigns a new or existing clinic to a staff member.
        /// </summary>
        public static string AssignClinicToStaff = $@"
        UPDATE {DatabaseHelper.Table("Staff")} 
        SET clinic = :clinic 
        WHERE sid = :sid";

        /// <summary>
        /// Updates all staff who are assigned to a specific clinic name.
        /// </summary>
        public static string UpdateClinicName = $@"
        UPDATE {DatabaseHelper.Table("Staff")} 
        SET clinic = :new 
        WHERE clinic = :old";

        /// <summary>
        /// Deletes a clinic assignment (sets to NULL) from all staff assigned to it.
        /// </summary>
        public static string DeleteClinic = $@"
        UPDATE {DatabaseHelper.Table("Staff")} 
        SET clinic = NULL 
        WHERE clinic = :clinic";

        //-------------------------------------
        //Zookeeper Assignment

        /// <summary>
        /// Retrieves all staff that are zookeepers (those listed in Oversees table).
        /// </summary>
        public static string SelectAllZookeepers = $@"
        SELECT s.sid, s.fName || ' ' || s.lName AS fullName
        FROM {DatabaseHelper.Table("Staff")} s
        WHERE s.sid IN (
            SELECT DISTINCT staffID FROM {DatabaseHelper.Table("Oversees")}
        )";

        /// <summary>
        /// Retrieves common names of all species groups.
        /// </summary>
        public static string SelectAllSpeciesGroupNames = $@"
        SELECT commonName 
        FROM {DatabaseHelper.Table("SpeciesGroup")} 
        ORDER BY commonName";

        /// <summary>
        /// Deletes all species group assignments for the specified staff member.
        /// </summary>
        public static string DeleteZookeeperAssignments = $@"
        DELETE FROM {DatabaseHelper.Table("Oversees")} 
        WHERE staffID = :sid";

        /// <summary>
        /// Inserts a new species group assignment for a zookeeper.
        /// </summary>
        public static string InsertZookeeperAssignment = $@"
        INSERT INTO {DatabaseHelper.Table("Oversees")} 
        (sGroupName, staffID) VALUES (:grp, :sid)";

        /// <summary>
        /// Retrieves assigned species groups for a given zookeeper.
        /// </summary>
        public static string SelectAssignedGroupsByStaff = $@"
        SELECT sGroupName 
        FROM {DatabaseHelper.Table("Oversees")} 
        WHERE staffID = :sid";

        /**<summary>
        * Gets the list of all animals that this staff member is qualified to feed and have previously been feed at least once.
        * @author Dolf ten Have.
        * </summary>
        * <param name="rows">The maximum number of rows returned.</param>
        * <param name="sid">The id of the staff member.</param>
        * <returns>A DataTable containg information about the animals that that person can feed.</returns>
        */
        public static DataTable getFeedingListForStaff(int rows, int sid)
        {

            if (currentDB == DBType.Oracle)
            {
                String query = $"SELECT a.aid, a.name, s3.commonName, f.datetime, a.feedingInterval " +
                    $"FROM {DatabaseHelper.Table("ANIMAL")} a " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("FEED")} f ON a.aid = f.animalid " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("SPECIES")} s3 ON a.speciesName = s3.latinName " +
                    $"WHERE a.aid IN " +
                    $"(SELECT a2.aid FROM {DatabaseHelper.Table("STAFF")} s2 " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("OVERSEES")} o2 ON s2.SID = o2.staffID " +
                    $"JOIN {DatabaseHelper.Table("SPECIESGROUP")} sg2 ON o2.sGroupName = sg2.latinName " +
                    $"JOIN {DatabaseHelper.Table("SPECIES")} s2 ON s2.speciesGroup = sg2.latinName " +
                    $"JOIN {DatabaseHelper.Table("ANIMAL")} a2 ON a2.speciesName = s2.latinName WHERE s2.sid = :sid) " +
                    $"AND f.dateTime = (SELECT MAX(dateTime) FROM {DatabaseHelper.Table("FEED")} f2 WHERE a.aid = f2.animalid) " +
                    $"ORDER BY f.dateTime ASC NULLS FIRST " +
                    $"FETCH FIRST :nrows ROWS ONLY";

                List<OracleParameter> parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter("sid", OracleDbType.Int32, sid, ParameterDirection.Input));
                parameters.Add(new OracleParameter("nrows", OracleDbType.Int32, rows, ParameterDirection.Input));

                return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

            }
            else
            {
                var pipeline = new[]
                {
                    new BsonDocument("$match",
                    new BsonDocument("sid", sid)),
                    new BsonDocument("$project",
                    new BsonDocument("oversees", 1)),
                    new BsonDocument("$lookup",
                    new BsonDocument
                        {
                            { "from", "speciesGroup" },
                            { "localField", "oversees.latinName" },
                            { "foreignField", "latinName" },
                            { "as", "speciesGroup" }
                        }),
                    new BsonDocument("$project",
                    new BsonDocument
                        {
                            { "speciesGroup.species.commonName", 1 },
                            { "speciesGroup.species.animals.aid", 1 },
                            { "speciesGroup.species.animals.name", 1 },
                            { "speciesGroup.species.animals.feedingInterval", 1 }
                        }),
                    new BsonDocument("$unwind",
                    new BsonDocument
                        {
                            { "path", "$speciesGroup" },
                            { "preserveNullAndEmptyArrays", true }
                        }),
                    new BsonDocument("$unwind",
                    new BsonDocument
                        {
                            { "path", "$speciesGroup.species" },
                            { "preserveNullAndEmptyArrays", true }
                        }),
                    new BsonDocument("$unwind",
                    new BsonDocument
                        {
                            { "path", "$speciesGroup.species.animals" },
                            { "preserveNullAndEmptyArrays", true }
                        }),
                    new BsonDocument("$lookup",
                    new BsonDocument
                        {
                            { "from", "Feed" },
                            { "localField", "speciesGroup.species.animals.aid" },
                            { "foreignField", "animalID" },
                            { "as", "Feed" }
                        }),
                    new BsonDocument("$match",
                    new BsonDocument("$expr",
                    new BsonDocument("$gt",
                    new BsonArray
                                {
                                    new BsonDocument("$size", "$Feed"),
                                    0
                                }))),
                    new BsonDocument("$project",
                    new BsonDocument
                        {
                            { "aid", "$speciesGroup.species.animals.aid" },
                            { "name", "$speciesGroup.species.animals.name" },
                            { "commonName", "$speciesGroup.species.commonName" },
                            { "datetime",
                    new BsonDocument("$max", "$Feed.datetime") },
                            { "feedingInterval", "$speciesGroup.species.animals.feedingInterval" }
                        }),
                    new BsonDocument("$sort",
                    new BsonDocument("datetime", 1)),
                    new BsonDocument("$limit", rows)
                };

                var data = MongoDBHelper.GetCollection(MongoDBHelper.DBCollection.Staff).Aggregate<BsonDocument>(pipeline).ToList();

                DataTable dt = new DataTable();

                dt.Columns.Add("aid", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("commonName", typeof(string));
                dt.Columns.Add("datetime", typeof(DateTime));
                dt.Columns.Add("feedingInterval", typeof(int));

                foreach (var animal in data)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = animal["aid"].AsInt32;
                    dr[1] = animal["name"].AsString;
                    dr[2] = animal["commonName"].AsString;
                    dr[3] = animal["datetime"].AsBsonDateTime.ToUniversalTime();
                    dr[4] = animal["feedingInterval"].AsInt32;
                    dt.Rows.Add(dr);
                }

                return dt;

            }
        }

        /**<summary>
         * Gets up to <param>rows</param> animals that this staff member is qualified to feed that have never been fed before.
         * This table may be empty if all animals have been fed at least once.
         * 
         * @Author Dolf ten Have
         * </summary>
         * <param name="rows">The maximum number of rows returned.</param>
         * <param name="sid">The id of the staff member.</param>
         * <returns>A Datatable with up to <param>rows</param> animals that have never been fed before.</returns>
         */
        public static DataTable getFeedingListForStaff_AnimalsNeverFed(int rows, int sid)
        {
            if (currentDB == DBType.Oracle)
            {
                String query = $"SELECT a.aid, a.name, s3.commonName, a.feedingInterval " +
                    $"FROM {DatabaseHelper.Table("ANIMAL")} a " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("SPECIES")} s3 ON a.speciesName = s3.latinName " +
                    $"WHERE a.aid IN " +
                    $"(SELECT a2.aid FROM {DatabaseHelper.Table("STAFF")} s2 " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("OVERSEES")} o2 ON s2.SID = o2.staffID " +
                    $"JOIN {DatabaseHelper.Table("SPECIESGROUP")} sg2 ON o2.sGroupName = sg2.latinName " +
                    $"JOIN {DatabaseHelper.Table("SPECIES")} s2 ON s2.speciesGroup = sg2.latinName " +
                    $"JOIN {DatabaseHelper.Table("ANIMAL")} a2 ON a2.speciesName = s2.latinName WHERE s2.sid = :sid) " +
                    // All the animals that are not in the feeding table
                    $"AND a.aid NOT IN (SELECT DISTINCT animalID FROM {DatabaseHelper.Table("FEED")})" +
                    $"FETCH FIRST :nrows ROWS ONLY";

                List<OracleParameter> parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter("sid", OracleDbType.Int32, sid, ParameterDirection.Input));
                parameters.Add(new OracleParameter("nrows", OracleDbType.Int32, rows, ParameterDirection.Input));
                return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            }
            else
            {
                var pipeline = new[]
                {
                new BsonDocument("$match",
                    new BsonDocument("sid", sid)),
                    new BsonDocument("$project",
                    new BsonDocument("oversees", 1)),
                    new BsonDocument("$lookup",
                    new BsonDocument
                        {
                            { "from", "speciesGroup" },
                            { "localField", "oversees.latinName" },
                            { "foreignField", "latinName" },
                            { "as", "speciesGroup" }
                        }),
                    new BsonDocument("$project",
                    new BsonDocument
                        {
                            { "speciesGroup.species.commonName", 1 },
                            { "speciesGroup.species.animals.aid", 1 },
                            { "speciesGroup.species.animals.name", 1 },
                            { "speciesGroup.species.animals.feedingInterval", 1 }
                        }),
                    new BsonDocument("$unwind",
                    new BsonDocument
                        {
                            { "path", "$speciesGroup" },
                            { "preserveNullAndEmptyArrays", true }
                        }),
                    new BsonDocument("$unwind",
                    new BsonDocument
                        {
                            { "path", "$speciesGroup.species" },
                            { "preserveNullAndEmptyArrays", true }
                        }),
                    new BsonDocument("$unwind",
                    new BsonDocument
                        {
                            { "path", "$speciesGroup.species.animals" },
                            { "preserveNullAndEmptyArrays", true }
                        }),
                    new BsonDocument("$lookup",
                    new BsonDocument
                        {
                            { "from", "Feed" },
                            { "localField", "speciesGroup.species.animals.aid" },
                            { "foreignField", "animalID" },
                            { "as", "Feed" }
                        }),
                    new BsonDocument("$match",
                    new BsonDocument("$expr",
                    new BsonDocument("$eq",
                    new BsonArray
                                {
                                    0,
                                    new BsonDocument("$size", "$Feed")
                                }))),
                    new BsonDocument("$project",
                    new BsonDocument
                        {
                            { "aid", "$speciesGroup.species.animals.aid" },
                            { "name", "$speciesGroup.species.animals.name" },
                            { "commonName", "$speciesGroup.species.commonName" },
                            { "feedingInterval", "$speciesGroup.species.animals.feedingInterval" }
                        }),
                    new BsonDocument("$limit", rows)
                };

                var data = MongoDBHelper.GetCollection(MongoDBHelper.DBCollection.Staff).Aggregate<BsonDocument>(pipeline).ToList();

                DataTable dt = new DataTable();

                dt.Columns.Add("aid", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("commonName", typeof (string));
                dt.Columns.Add("feedingInterval", typeof(int));

                foreach(var animal in data)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = animal["aid"].AsInt32;
                    dr[1] = animal["name"].AsString;
                    dr[2] = animal["commonName"].AsString;
                    dr[3] = animal["feedingInterval"].AsInt32;
                    dt.Rows.Add(dr);
                }

                return dt;
            }

        }

        /**<summary>
         * Searches for all enclosures who's name is a partial match for the current string in the search box
         * </summary>
         * <param name="name" type="String">The name of the enclosure.</param>
         * <returns>A DataTable with a list of all enclosure names that match the current search. May be empty.</returns>
         */
        public static DataTable getEnclosuresByName(string name)
        {
                if (getDBType() == DBType.Oracle) { 
                String query = $"SELECT eid, name FROM {DatabaseHelper.Table("ENCLOSURE")} WHERE name LIKE :name";
                List<OracleParameter> parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter("name", OracleDbType.Varchar2, $"%{name}%", ParameterDirection.Input));
                return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            }
            else
            {
                BsonDocument[] pipeline = new[]
                {
                     new BsonDocument("$unwind",
                        new BsonDocument
                            {
                                { "path", "$enclosures" },
                                { "preserveNullAndEmptyArrays", true }
                            }),
                        new BsonDocument("$project",
                            new BsonDocument
                            {
                                { "eid", "$enclosures.eid" },
                                { "name", "$enclosures.name" }
                            }),
                        new BsonDocument("$match",
                        new BsonDocument("name",
                        new BsonDocument("$regex", $"[a-zA-Z]*{name}[a-zA-Z]*")))
                };

                var data = MongoDBHelper.GetCollection(MongoDBHelper.DBCollection.Zone).Aggregate<BsonDocument>(pipeline).ToList();

                DataTable dt = new DataTable();

                dt.Columns.Add("eid", typeof(int));
                dt.Columns.Add("name", typeof(string));

                foreach (var animal in data)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = animal["eid"].AsInt32;
                    dr[1] = animal["name"].AsString;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }

        /**<summary>
         * Gets the Name of an enclosure based on the id
         * </summary>
         * <param name="eid">The enclosure ID.</param>
         * <returns>
         * A DataTable containing the Name of the enclosure.
         * </returns>
         */
        public static DataTable getEnclosureNameById(int eid)
        {
            
            if (getDBType() == DBType.Oracle)
            {
            
                String query = $"SELECT name FROM {DatabaseHelper.Table("ENCLOSURE")} WHERE eid = :eid";
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(new OracleParameter("eid", OracleDbType.Int32, eid, ParameterDirection.Input));
                return DatabaseHelper.ExecuteQuery(query, paramList.ToArray());
                
            }
            else
            {
                DataTable dt = new DataTable();

                BsonDocument[] pipeline = new BsonDocument[]{
                    new BsonDocument("$unwind",
                    new BsonDocument("path", "$enclosures")),
                    new BsonDocument("$match",
                    new BsonDocument("enclosures.eid", eid)),
                    new BsonDocument("$project",
                    new BsonDocument("name", "$enclosures.name"))
                };

                var data = MongoDBHelper.GetCollection(MongoDBHelper.DBCollection.Zone).Aggregate<BsonDocument>(pipeline).ToList();

                string name = data.ElementAt(0)["name"].ToString();

                dt.Columns.Add("name");
                DataRow dr = dt.NewRow();
                dr[0] = name;
                dt.Rows.Add(dr);

                return dt;
            }
                
        }

        /**<summary>
         * Return all the animals from a given enclosure that the given staff member is allowed to care for.
         * </summary>
         * <param name="sid">Staff ID</param>
         * <param name="eid">Enclosure ID</param>
         * <returns>A datatable with the animal id, name, species, last fed date and feeding interval for each animal.</returns>
         */
        public static DataTable getEnclosureAnimals(int sid, int eid)
        {
            if (currentDB == DBType.Oracle)
            {
                String query = $"SELECT a.aid, a.name, a.speciesName, f.datetime " +
                    $"FROM {DatabaseHelper.Table("ANIMAL")} a " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("FEED")} f ON a.aid = f.animalid " +
                    $"WHERE enclosureID = :eid AND a.aid IN " +
                    $"(SELECT a2.aid FROM {DatabaseHelper.Table("STAFF")} s2 " +
                    $"LEFT OUTER JOIN {DatabaseHelper.Table("OVERSEES")} o2 ON s2.SID = o2.staffID " +
                    $"JOIN {DatabaseHelper.Table("SPECIESGROUP")} sg2 ON o2.sGroupName = sg2.latinName " +
                    $"JOIN {DatabaseHelper.Table("SPECIES")} s2 ON s2.speciesGroup = sg2.latinName " +
                    $"JOIN {DatabaseHelper.Table("ANIMAL")} a2 ON a2.speciesName = s2.latinName WHERE s2.sid = :sid ) " +
                    $"AND f.dateTime = (SELECT MAX(dateTime) FROM {DatabaseHelper.Table("FEED")} f2 WHERE a.aid = f2.animalid) ";
                List<OracleParameter> parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter("eid", OracleDbType.Int32, eid, ParameterDirection.Input));
                parameters.Add(new OracleParameter("sid", OracleDbType.Int32, sid, ParameterDirection.Input));
                return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            }
            else
            {
                var pipeline = new[]
                {
                      new BsonDocument("$match",
                        new BsonDocument("sid", sid)),
                        new BsonDocument("$project",
                        new BsonDocument("oversees", 1)),
                        new BsonDocument("$lookup",
                        new BsonDocument
                            {
                                { "from", "speciesGroup" },
                                { "localField", "oversees.latinName" },
                                { "foreignField", "latinName" },
                                { "as", "speciesGroup" }
                            }),
                        new BsonDocument("$project",
                        new BsonDocument
                            {
                                { "speciesGroup.species.commonName", 1 },
                                { "speciesGroup.species.animals.aid", 1 },
                                { "speciesGroup.species.animals.name", 1 },
                                { "speciesGroup.species.animals.feedingInterval", 1 }
                            }),
                        new BsonDocument("$unwind",
                        new BsonDocument
                            {
                                { "path", "$speciesGroup" },
                                { "preserveNullAndEmptyArrays", true }
                            }),
                        new BsonDocument("$unwind",
                        new BsonDocument
                            {
                                { "path", "$speciesGroup.species" },
                                { "preserveNullAndEmptyArrays", true }
                            }),
                        new BsonDocument("$unwind",
                        new BsonDocument
                            {
                                { "path", "$speciesGroup.species.animals" },
                                { "preserveNullAndEmptyArrays", true }
                            }),
                        new BsonDocument("$lookup",
                        new BsonDocument
                            {
                                { "from", "Feed" },
                                { "localField", "speciesGroup.species.animals.aid" },
                                { "foreignField", "animalID" },
                                { "as", "Feed" }
                            }),
                        new BsonDocument("$match",
                        new BsonDocument("$expr",
                        new BsonDocument("$gt",
                        new BsonArray
                                    {
                                        new BsonDocument("$size", "$Feed"),
                                        0
                                    }))),
                        new BsonDocument("$project",
                        new BsonDocument
                            {
                                { "aid", "$speciesGroup.species.animals.aid" },
                                { "name", "$speciesGroup.species.animals.name" },
                                { "commonName", "$speciesGroup.species.commonName" },
                                { "datetime",
                        new BsonDocument("$max", "$Feed.datetime") },
                                { "feedingInterval", "$speciesGroup.species.feedingInterval" }
                            }),
                        new BsonDocument("$sort",
                        new BsonDocument("datetime", 1)),
                        new BsonDocument("$lookup",
                        new BsonDocument
                            {
                                { "from", "Zone" },
                                { "pipeline",
                        new BsonArray
                                {
                                    new BsonDocument("$unwind",
                                    new BsonDocument("path", "$enclosures")),
                                    new BsonDocument("$match",
                                    new BsonDocument("enclosures.eid", eid)),
                                    new BsonDocument("$unwind",
                                    new BsonDocument("path", "$enclosures.animal")),
                                    new BsonDocument("$project",
                                    new BsonDocument("animalID", "$enclosures.animal.aid"))
                                } },
                                { "as", "enclosure" }
                            }),
                        new BsonDocument("$unwind",
                        new BsonDocument("path", "$enclosure")),
                        new BsonDocument("$match",
                        new BsonDocument("$expr",
                        new BsonDocument("$eq",
                        new BsonArray
                                    {
                                        "$aid",
                                        "$enclosure.animalID"
                                    }))),
                        new BsonDocument("$project",
                        new BsonDocument("enclosure", 0))
                };

                var data = MongoDBHelper.GetCollection(MongoDBHelper.DBCollection.Staff).Aggregate<BsonDocument>(pipeline).ToList();

                DataTable dt = new DataTable();

                dt.Columns.Add("aid", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("commonName", typeof(string));
                dt.Columns.Add("datetime",typeof(DateTime));

                foreach (var animal in data)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = animal["aid"].AsInt32;
                    dr[1] = animal["name"].AsString;
                    dr[2] = animal["commonName"].AsString;
                    dr[3] = animal["datetime"].AsBsonDateTime.ToUniversalTime();
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }
    }
}

