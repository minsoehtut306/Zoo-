# Mongo DB

This folder contains all the documents needed to implement zoo.sql in mongodb.

## Collections

There are 6 total json documents. Each of which will go into their own collection.

- [Care](Care.json) containing all the care information for each animal.
- [Feed](Feed.json) Containgin all the Feeding information for each anonimal.
- [Oversees](Oversees.json) Containing all the information of which zooKeeper oversees what speciesGroup.
- [Staff](Staff.json) StaffInfo.
- [Zone](Zone.json) Zone, Enclosure.
- [SpeciesGroup](speciesGroup.json) SpeasiesGroup, Species and Animal.

[ER diagram](https://lucid.app/lucidchart/62e459d5-6a2c-4536-8235-2b0af8881b8c/edit?invitationId=inv_ec5c393a-edbf-48fc-a2c2-229d7e7fc4e2&page=0_0#).

### Staff

The top staff is a zookeeper and the bottom staff member is a vet.

```json
{
 "sid":1,
 "fname":"jason",
 "lname":"mamoa",
 "dob":{"$date":"YYYY-mm-dd"},
 "phoneNumber":"+64234567890",
 "email":"example@email.com",
 "address":{
     "street_num":"23a",
     "street_name":"street",
     "suburb":"sub",
     "city":"cityname",
     "postcode":"0123"
  },
 "sex":"M",
 "overSees":[
    {"latinName":"sg1"},
    {"latinName":"sg2"}
    ]
}
{
 "sid":1,
 "fname":"jason",
 "lname":"mamoa",
 "dob":{"$date":"YYYY-mm-dd"},
 "phoneNumber":"+64234567890",
 "email":"example@email.com",
 "address":{
    "street_num":"23a",
     "street_name":"street",
     "suburb":"sub",
     "city":"cityname",
     "postcode":"0123"
 },
 "sex":"M",
 "clinic":"this is a vet clinic",
}
```

### SpeciesGroup

```json
{
   "latin_name": "lName1",
   "common_name":"name1",
   "species":[
        {"latin_name":"lName11",
        "common_name":"name11",
        "requred_biome":"biome",
        "animal":[
        {
            "aid":1,
            "name":"bon",
            "weight":12.90,
            "originCountry":"NLD",
            "dob":{"$date":"YYYY-mm-dd"},
            "sex":"M",
            "feedin_interval":24
        }]
    }]
}
```

### Zone

```json
{
    "name":"e1",
    "Colour":"White",
    "hex_value":"ffffff",
    "enclosure":[
        { "eid":1,
        "biome":"jungle",
        "size":25,
        "animals":[
        {"aid":1}
    ]}
}
```

### Feed

```json
{
    "dateTime":{"$date":"YYYY-mm-ddTHH:MM:ss"},
    "care":"recieved",
    "notes":"care_notes",
    "animal":1,
    "staff":1
}
```

### Care

```json
{
    "dateTime":{"$date":"YYYY-mm-ddTHH:MM:ss"},
    "food_type": "food",
    "ammount":124.00,
    "animal":1,
    "staff":1
}
```
