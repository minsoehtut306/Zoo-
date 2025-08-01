/*
DROP TABLE m2_Ate;
DROP TABLE m2_Care;
DROP TABLE m2_Oversees;
DROP TABLE m2_Staff;
DROP TABLE m2_Animal;
DROP TABLE m2_Species;
DROP TABLE m2_Enclosure;
DROP TABLE m2_Zone;
DROP TABLE m2_SpeciesGroup;
*/

CREATE TABLE m2_SpeciesGroup(
    latinName VARCHAR(30) PRIMARY KEY, 
    commonName VARCHAR(30)
);

CREATE TABLE m2_Zone(
    name VARCHAR(30) PRIMARY KEY
    colour VARCHAR(15)
);

CREATE TABLE m2_Enclosure(
    eid INTEGER PRIMARY KEY,
    biome VARCHAR(15),
    size INTEGER,
    zoneName VARCHAR(30),
    CONSTRAINT zoneCheck
        FOREIGN KEY (zoneName) REFERENCES m2_Zone(name)
        ON DELETE SET NULL
);

CREATE TABLE m2_Species(
    latinName VARCHAR(30) PRIMARY KEY,
    commonName VARCHAR(30),
    requiredBiome VARCHAR(15),
    speciesGroup VARCHAR(30),
    CONSTRAINT speciesGroupCheck
        FOREIGN KEY (speciesGroup) REFERENCES m2_SpeciesGroup(latinName)
        ON DELETE CASCADE
);

CREATE TABLE m2_Animal(
    aid INTEGER PRIMARY KEY,
    -- 0 for Unknown, 1 for M, 2 for F, 3 for N/A
    -- https://en.wikipedia.org/wiki/ISO/IEC_5218
    sex TINYINT,
    feedingInterval INTEGER,
    name VARCHAR(30),
    -- Heaviest land animal: elephant (can be 10t!)
    -- This assumes the zoo doesn't have whales.
    -- 4dp because of exceptionally light animals
    weight DECIMAL(9,4),
    -- Follows standardised three letter codes for each country
    -- https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3
    -- For unknown origin, use code 'XXX'
    originCountry CHAR(3),
    dob DATE,
    enclosureID INTEGER,
    speciesName VARCHAR(30),

    CONSTRAINT sexCheck
        CHECK (sex>=0 AND sex <= 3),
    
    CONSTRAINT feedingIntervalCheck
        CHECK (feedingInterval > 0),

    CONSTRAINT weightCheck
        CHECK (weight > 0),

    CONSTRAINT countryCodeLengthCheck
        CHECK (length(originCountry) = 3),

    CONSTRAINT animalEnclosureCheck
        FOREIGN KEY (enclosureID) REFERENCES m2_Enclosure(eid)
        ON DELETE SET NULL,

    CONSTRAINT speciesNameCheck
        FOREIGN KEY (speciesName) REFERENCES m2_Species(latinName)
        ON DELETE CASCADE
);

CREATE TABLE m2_Staff(
    sid INTEGER PRIMARY KEY,
    fName VARCHAR(20),
    lName VARCHAR(20),
    dob DATE,
    -- might need to change this.
    -- https://en.wikipedia.org/wiki/E.164
    phNumber INTEGER,
    email VARCHAR(MAX),
    address VARCHAR(MAX),
    clinic VARCHAR (50),

    CONSTRAINT reasonableStaffDateOB
        CHECK (dob > TO_DATE('01.01.1900', 'DD.MM.YYYY'))
);

CREATE TABLE m2_Oversees(
    sGroupName VARCHAR(30),
    staffID INTEGER,
    PRIMARY KEY (sGroupName, staffID),
    CONSTRAINT checkValidSGroup
        FOREIGN KEY (sGroupName) REFERENCES m2_SpeciesGroup(latinName)
        ON DELETE CASCADE,
    CONSTRAINT checkValidStaffID
        FOREIGN KEY (staffID) REFERENCES m2_Staff(sid)
        ON DELETE CASCADE
);

CREATE TABLE m2_Care(
    staffID INTEGER,
    animalID INTEGER,
    dateTime TIMESTAMP,
    care VARCHAR(30),
    notes VARCHAR(MAX),
    PRIMARY KEY (staffID, animalID, dateTime),
    CONSTRAINT checkValidStaffID2
        FOREIGN KEY (staffID) REFERENCES m2_Staff(sid)
        -- can I even do this??
        ON DELETE SET NULL,
    CONSTRAINT checkValidAnimalID
        FOREIGN KEY (animalID) REFERENCES m2_Animal(aid)
        ON DELETE CASCADE
);

CREATE TABLE m2_Ate(
    staffID INTEGER,
    animalID INTEGER,
    dateTime TIMESTAMP,
    -- could swap this to a more precise numeric type?
    amount INTEGER,
    foodType VARCHAR(15),
    PRIMARY KEY (staffID, animalID, dateTime),
    CONSTRAINT checkValidStaffID2
        FOREIGN KEY (staffID) REFERENCES m2_Staff(sid)
        -- can I even do this??
        ON DELETE SET NULL,
    CONSTRAINT checkValidAnimalID
        FOREIGN KEY (animalID) REFERENCES m2_Animal(aid)
        ON DELETE CASCADE
);