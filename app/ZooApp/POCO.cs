using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;

/**
 * <author>Dolf ten Have</author>
 * <summary>
 * A set of POCO classes for the mongoDB application.
 * </summary>
 */
namespace ZooApp.POCO
{
    /**********************************************************
     *              Zone Table
     * *******************************************************/

    /**<summary>The Zone field</summary>
     */
    public class Zone
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("colour")]
        public string colour { get; set; }
        [BsonElement("hexcode")]
        public string hexcode { get; set; }
        [BsonElement("enclosures")]
        public List<Enclosure> enclosures { get; set; }

    }

    public class Enclosure
    {
        [BsonElement("eid")]
        public int eid { get; set; }
        [BsonElement("name")]
        public string name { set; get; }
        [BsonElement("biome")]
        public string biome { set; get; }
        [BsonElement("eSize")]
        public int eSize { set; get; }
        [BsonElement("animal")]
        public List<Animal_Zone> animals { get; set; }
    }

    public class Animal_Zone
    {
        [BsonElement("aid")]
        public int aid { set; get; }
    }



    /***************************************
     *          Staff Table
     * **************************************/

    public class Staff
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("sid")]
        public int sid { set; get; }

        [BsonElement("fName")]
        public string fName { set; get; }

        [BsonElement("lName")]
        public string lName { set; get; }
        [BsonElement("dob")]
        public DateTime dob { set; get; }

        [BsonElement("phoneNumber")]
        public string phoneNumber { get; set; }

        [BsonElement("address")]
        public Address_Staff address { set; get; }

        [BsonElement("sex")]
        public string sex {  set; get; }
        [BsonElement("oversees")]
        public List<SpeciesGroup_Staff> oversees { get; set; }
    }

    public class Address_Staff
    {
        [BsonElement("streetNumber")]
        public int streetNumber { set; get; }
        [BsonElement("streetName")]
        public string streetName { set; get; }
        [BsonElement("suburb")]
        public string suburb { set; get; }
        [BsonElement("city")]
        public string city { set; get; }
        [BsonElement("postCode")]
        public string postCode { set; get; }
    }

    public class SpeciesGroup_Staff
    {
        [BsonElement("latinName")]
        public string latinName { set; get; }
    }

    /*****************************************
     *              SpeciesGroup
     *              ****************************/

    public class SpeciesGroup
    {
        [BsonId]
        public int _id { set; get; }
        [BsonElement("latinName")]
        public string latinName { set; get; }
        [BsonElement("commonName")]
        public string commonName { set; get; }
        [BsonElement("species")]
        public List<Species> species { set; get; }
    }

    public class Species
    {
        [BsonElement("latinName")]
        public string latinName { set; get; }
        [BsonElement("commonName")]
        public string commonName { set; get; }
        [BsonElement("requiredBiome")]
        public string requiredBiome { set; get; }
        [BsonElement("animals")]
        public List<Animal> animals { set; get; }
    }

    public class Animal
    {
        [BsonElement("aid")]
        public int aid { set; get; }
        [BsonElement("sed")]
        public string sex { set; get; }
        [BsonElement("feedingInterval")]
        public int feedingInterval { set; get; }
        [BsonElement("name")]
        public string name { set; get; }
        [BsonElement("weight")]
        public double weight { set; get; }
        [BsonElement("originCountry")]
        public string originCountry { set; get; }
        [BsonElement("dob")]
        public DateTime dob { set; get; }
    }

    public class Care
    {
        [BsonId]
        public int _id { set; get; }
        [BsonElement("staffID")]
        public int staffID {  set; get; }
        [BsonElement("animalID")]
        public int animalID {  set; get; }
        [BsonElement("datetime")]
        public DateTime DateTime { set; get; }
        [BsonElement("care")]
        public string care { set; get; }
        [BsonElement("notes")]
        public string notes { set; get; }
    }

    public class Feed
    {
        [BsonId]
        public int _id { set; get; }
        [BsonElement("staffID")]
        public int staffID { set; get; }
        [BsonElement("animalID")]
        public int animalID { set; get; }
        [BsonElement("datetime")]
        public DateTime DateTime { set; get; }
        [BsonElement("amount")]
        public double amount {  set; get; }
        [BsonElement("foodType")]
        public string foodType { set; get; }
    }
}
