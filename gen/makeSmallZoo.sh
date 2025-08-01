#!/bin/bash

# This file creates a small test version of the large dataset
# @author Dolf ten Have

# A list of clinics
java parseArgs Clinics clinic -v 10
java MakeCSV 5 "tables/Clinics.tab" Clinics

# Initialization of all the table files
java parseArgs SpeciesGroup latinname commonName -V 10 -v 30
java parseArgs Zone name colour hexCode -V 10 -v 15 -h 6
java parseArgs Enclosure eid name biome eSize zoneName -I 1 -v 30 -v 15 -i 4 -F "Zone.csv" 0 
java parseArgs Species latinName commonName requiredBiome speciesGroup -V 20 -v 30 -f "Enclosure.csv" 2 -F "SpeciesGroup.csv" 0
java parseArgs Staff sid fName lName dob phNumber email streetNumber streetName suburb city postCode clinic sex -I 1 -v 6 -v 10 -d -p -e -i 3 -v 6 -v 7 -v 8 -i 4 -N -g
java parseArgs VetStaff sid fName lName dob phNumber email streetNumber streetName suburb city postCode clinic sex -I 100 -v 6 -v 10 -d -p -e -i 3 -v 6 -v 7 -v 8 -i 4 -f "Clinics.csv" 0 -g
java parseArgs Animal aid sex feedingInterval name weight originCountry dob enclosureID speciesName -I 1 -g -x -v 8 -o 10 2 -f "data/slim-3.csv" 1 -d -F "Enclosure.csv" 0 -F "Species.csv" 0
java parseArgs Oversees sGroupName staffID -F "SpeciesGroup.csv" 0 -F "Staff.csv" 0
java parseArgs Care staffID animalID dateTime care notes -F "VetStaff.csv" 0 -F "Animal.csv" 0 -T -F "data/care.csv" 0 -v 20
java parseArgs Feed staffID animalID dateTime amount foodType -F "Staff.csv" 0 -F "Animal.csv" 0 -T -o 5 2 -F "data/food.csv" 0

# Creation of mock data
java MakeCSV 11 "tables/SpeciesGroup.tab" SpeciesGroup
java MakeCSV 5 "tables/Zone.tab" Zone
java MakeCSV 20 "tables/Enclosure.tab" Enclosure
java MakeCSV 20 "tables/Species.tab" Species
java MakeCSV 30 "tables/Animal.tab" Animal
java MakeCSV 10 "tables/Staff.tab" Staff
java MakeCSV 5 "tables/VetStaff.tab" VetStaff
java MakeCSV 30 "tables/Oversees.tab" Oversees
java MakeCSV 50 "tables/Care.tab" Care
java MakeCSV 50 "tables/Feed.tab" Feed
# total 957,000 lines

# Appends the VetStaff to the end of the staff file, skipping the csv header.
# The cariage return is removed when I append the head +2 to the end of the firest file. So I add a blank line and then it appends to the end of that. This ensures that the top of the vetstaff file starts on a new line.
echo "" >> Staff.csv
tail -n +2 VetStaff.csv >> Staff.csv
rm VetStaff.csv
rm Clinics.csv

rm -r small/*.csv
mv *.csv small/


