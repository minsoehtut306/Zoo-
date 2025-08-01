-- Drop tables safely (if they exist)
BEGIN

    EXECUTE IMMEDIATE 'DROP TABLE m2s_Feed CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Care CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Oversees CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Animal CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Species CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Enclosure CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Zone CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_SpeciesGroup CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2s_Staff CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

CREATE TABLE m2s_SpeciesGroup(
    latinName VARCHAR(30) PRIMARY KEY, 
    commonName VARCHAR(30) NOT NULL
);

CREATE TABLE m2s_Zone(
    name VARCHAR(30) PRIMARY KEY,
    colour VARCHAR(15) NOT NULL,
    hexcode VARCHAR(6) NOT NULL
);

CREATE TABLE m2s_Enclosure(
    eid INTEGER PRIMARY KEY,
	name VARCHAR(30) NOT NULL,
    biome VARCHAR(15) NOT NULL,
    eSize INTEGER NOT NULL,
    zoneName VARCHAR(30) NOT NULL,
    CONSTRAINT m2s_Enclosure_zoneCheck
        FOREIGN KEY (zoneName) REFERENCES m2s_Zone(name)
        ON DELETE SET NULL
);

CREATE TABLE m2s_Species(
    latinName VARCHAR(30) PRIMARY KEY,
    commonName VARCHAR(30) NOT NULL,
    requiredBiome VARCHAR(15) NOT NULL,
    speciesGroup VARCHAR(30) NOT NULL,
    CONSTRAINT m2s_Species_speciesGroupCheck
        FOREIGN KEY (speciesGroup) REFERENCES m2s_SpeciesGroup(latinName)
        ON DELETE CASCADE
);

CREATE TABLE m2s_Staff(
	sid INTEGER PRIMARY KEY,
    fName VARCHAR2(20) NOT NULL,
    lName VARCHAR2(20) NOT NULL,
    dob DATE NOT NULL,
   
    phNumber VARCHAR2(13) NOT NULL,
    email VARCHAR2(320) NOT NULL,
    streetNumber INTEGER NOT NULL,
    streetName VARCHAR2(30) NOT NULL,
    suburb VARCHAR2(30) NOT NULL,
    city VARCHAR2(30) NOT NULL,
    postCode VARCHAR2(4) NOT NULL,
    clinic VARCHAR2(50),
    sex CHAR(1) CHECK (sex IN ('F','M')) NOT NULL,
    CONSTRAINT m2s_staff_dobCheck CHECK (dob > TO_DATE('1900-01-01', 'YYYY-MM-DD'))
);

CREATE TABLE m2s_Animal(
    aid INTEGER PRIMARY KEY,
    sex CHAR(1) CHECK (sex IN ('F','M')) NOT NULL,
    feedingInterval INTEGER NOT NULL,
    name VARCHAR2(30) NOT NULL,
    weight DECIMAL(10,2) NOT NULL,
    originCountry CHAR(3) NOT NULL,
    dob DATE NOT NULL,
    enclosureID INTEGER,
    speciesName VARCHAR2(30) NOT NULL,
    CONSTRAINT m2s_Animal_feedingInterval CHECK (feedingInterval > 0),
    CONSTRAINT m2s_Animal_weight CHECK (weight > 0),
    CONSTRAINT m2s_Animal_originCountry CHECK (LENGTH(originCountry) = 3),
    CONSTRAINT m2s_Animal_enclosureID FOREIGN KEY (enclosureID) REFERENCES m2s_Enclosure(eid) ON DELETE SET NULL,
    CONSTRAINT m2s_Animal_speciesName FOREIGN KEY (speciesName) REFERENCES m2s_Species(latinName) ON DELETE CASCADE
);

CREATE TABLE m2s_Oversees(
    sGroupName VARCHAR(30),
    staffID INTEGER,
    PRIMARY KEY (sGroupName, staffID),
    CONSTRAINT m2s_Oversees_checkValidSGroup
        FOREIGN KEY (sGroupName) REFERENCES m2s_SpeciesGroup(latinName)
        ON DELETE CASCADE,
    CONSTRAINT m2s_Oversees_checkValidStaffID
        FOREIGN KEY (staffID) REFERENCES m2s_Staff(sid)
        ON DELETE CASCADE
);

CREATE TABLE m2s_Care(
    staffID INTEGER,
    animalID INTEGER,
    dateTime TIMESTAMP,
    care VARCHAR2(30) NOT NULL,
    notes VARCHAR2(300),
    PRIMARY KEY (staffID, animalID, dateTime),
    CONSTRAINT m2s_fk_staffID_care FOREIGN KEY (staffID) REFERENCES m2s_Staff(sid) ON DELETE SET NULL,
    CONSTRAINT m2s_fk_animalID_care FOREIGN KEY (animalID) REFERENCES m2s_Animal(aid) ON DELETE CASCADE
);

CREATE TABLE m2s_Feed(
    staffID INTEGER,
    animalID INTEGER,
    dateTime TIMESTAMP,
    amount DECIMAL(7,2) NOT NULL,
    foodType VARCHAR2(30) NOT NULL,
    PRIMARY KEY (staffID, animalID, dateTime),
    CONSTRAINT m2s_feed_StaffIdCheck FOREIGN KEY (staffID) REFERENCES m2s_Staff(sid) ON DELETE SET NULL,
    CONSTRAINT m2s_feed_animalID FOREIGN KEY (animalID) REFERENCES m2s_Animal(aid) ON DELETE CASCADE
);

--------------------------------------------------
-- Tables for large dataset
-------------------------------------------------
-- Drop tables safely (if they exist)
BEGIN

    EXECUTE IMMEDIATE 'DROP TABLE m2l_Feed CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Care CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Oversees CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Animal CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Species CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Enclosure CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Zone CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_SpeciesGroup CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE m2l_Staff CASCADE CONSTRAINTS';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

CREATE TABLE m2l_SpeciesGroup(
    latinName VARCHAR(30) PRIMARY KEY, 
    commonName VARCHAR(30) NOT NULL
);

CREATE TABLE m2l_Zone(
    name VARCHAR(30) PRIMARY KEY,
    colour VARCHAR(15) NOT NULL,
    hexcode VARCHAR(6) NOT NULL
);

CREATE TABLE m2l_Enclosure(
    eid INTEGER PRIMARY KEY,
	name VARCHAR(30) NOT NULL,
    biome VARCHAR(15) NOT NULL,
    eSize INTEGER NOT NULL,
    zoneName VARCHAR(30) NOT NULL,
    CONSTRAINT m2l_Enclosure_zoneCheck
        FOREIGN KEY (zoneName) REFERENCES m2l_Zone(name)
        ON DELETE SET NULL
);

CREATE TABLE m2l_Species(
    latinName VARCHAR(30) PRIMARY KEY,
    commonName VARCHAR(30) NOT NULL,
    requiredBiome VARCHAR(15) NOT NULL,
    speciesGroup VARCHAR(30) NOT NULL,
    CONSTRAINT m2l_Species_speciesGroupCheck
        FOREIGN KEY (speciesGroup) REFERENCES m2l_SpeciesGroup(latinName)
        ON DELETE CASCADE
);

CREATE TABLE m2l_Staff(
	sid INTEGER PRIMARY KEY,
    fName VARCHAR2(20) NOT NULL,
    lName VARCHAR2(20) NOT NULL,
    dob DATE NOT NULL,
   
    phNumber VARCHAR2(13) NOT NULL,
    email VARCHAR2(320) NOT NULL,
    streetNumber INTEGER NOT NULL,
    streetName VARCHAR2(30) NOT NULL,
    suburb VARCHAR2(30) NOT NULL,
    city VARCHAR2(30) NOT NULL,
    postCode VARCHAR2(4) NOT NULL,
    clinic VARCHAR2(50),
    sex CHAR(1) CHECK (sex IN ('F','M')) NOT NULL,
    CONSTRAINT m2l_staff_dobCheck CHECK (dob > TO_DATE('1900-01-01', 'YYYY-MM-DD'))
);

CREATE TABLE m2l_Animal(
    aid INTEGER PRIMARY KEY,
    sex CHAR(1) CHECK (sex IN ('F','M')) NOT NULL,
    feedingInterval INTEGER NOT NULL,
    name VARCHAR2(30) NOT NULL,
    weight DECIMAL(10,2) NOT NULL,
    originCountry CHAR(3) NOT NULL,
    dob DATE NOT NULL,
    enclosureID INTEGER,
    speciesName VARCHAR2(30) NOT NULL,
    CONSTRAINT m2l_Animal_feedingInterval CHECK (feedingInterval > 0),
    CONSTRAINT m2l_Animal_weight CHECK (weight > 0),
    CONSTRAINT m2l_Animal_originCountry CHECK (LENGTH(originCountry) = 3),
    CONSTRAINT m2l_Animal_enclosureID FOREIGN KEY (enclosureID) REFERENCES m2l_Enclosure(eid) ON DELETE SET NULL,
    CONSTRAINT m2l_Animal_speciesName FOREIGN KEY (speciesName) REFERENCES m2l_Species(latinName) ON DELETE CASCADE
);

CREATE TABLE m2l_Oversees(
    sGroupName VARCHAR(30),
    staffID INTEGER,
    PRIMARY KEY (sGroupName, staffID),
    CONSTRAINT m2l_Oversees_checkValidSGroup
        FOREIGN KEY (sGroupName) REFERENCES m2l_SpeciesGroup(latinName)
        ON DELETE CASCADE,
    CONSTRAINT m2l_Oversees_checkValidStaffID
        FOREIGN KEY (staffID) REFERENCES m2l_Staff(sid)
        ON DELETE CASCADE
);

CREATE TABLE m2l_Care(
    staffID INTEGER,
    animalID INTEGER,
    dateTime TIMESTAMP,
    care VARCHAR2(30) NOT NULL,
    notes VARCHAR2(300),
    PRIMARY KEY (staffID, animalID, dateTime),
    CONSTRAINT m2l_fk_staffID_care FOREIGN KEY (staffID) REFERENCES m2l_Staff(sid) ON DELETE SET NULL,
    CONSTRAINT m2l_fk_animalID_care FOREIGN KEY (animalID) REFERENCES m2l_Animal(aid) ON DELETE CASCADE
);

CREATE TABLE m2l_Feed(
    staffID INTEGER,
    animalID INTEGER,
    dateTime TIMESTAMP,
    amount DECIMAL(7,2) NOT NULL,
    foodType VARCHAR2(30) NOT NULL,
    PRIMARY KEY (staffID, animalID, dateTime),
    CONSTRAINT m2l_feed_StaffIdCheck FOREIGN KEY (staffID) REFERENCES m2l_Staff(sid) ON DELETE SET NULL,
    CONSTRAINT m2l_feed_animalID FOREIGN KEY (animalID) REFERENCES m2l_Animal(aid) ON DELETE CASCADE
);
