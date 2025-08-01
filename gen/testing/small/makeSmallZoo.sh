#!/bin/bash

# @author Dolf ten Have

# Initialization of all the table files
java parseArgs SpeciesGroup -V 10 -v 30
java parseArgs Zone -V 10 -v 15 -h 6
java parseArgs Enclosure -I 1 -v 15 -i 4 -F "csv/Zone.csv" 0 
java parseArgs Species -V 20 -v 30 -f "csv/Enclosure.csv" 2 -F "csv/SpeciesGroup.csv" 0
java parseArgs Staff -I 1 -v 6 -v 10 -d -p -e -i 3 -v 6 -v 7 -v 8 -i 4 -v 1 -g
java parseArgs Animal -I 1 -g -i 2 -v 8 -o 10 2 -f "csv/slim-3.csv" 1 -d -F "csv/Enclosure.csv" 0 -F "csv/Species.csv" 0
java parseArgs Oversees -F "csv/SpeciesGroup.csv" 0 -F "csv/Staff.csv" 0
java parseArgs Care -F "csv/Staff.csv" 0 -F "csv/Animal.csv" 0 -T -F "csv/care.csv" 0 -v 20
java parseArgs Feed -F "csv/Staff.csv" 0 -F "csv/Animal.csv" 0 -T -o 5 2 -F "csv/food.csv" 0

# Creation of mock data
java MakeCSV 10 "tables/SpeciesGroup.tab" SpeciesGroup
java MakeCSV 5 "tables/Zone.tab" Zone
java MakeCSV 20 "tables/Enclosure.tab" Enclosure
java MakeCSV 20 "tables/Species.tab" Species
java MakeCSV 30 "tables/Animal.tab" Animal
java MakeCSV 10 "tables/Staff.tab" Staff
java MakeCSV 30 "tables/Oversees.tab" Oversees
java MakeCSV 50 "tables/Care.tab" Care
java MakeCSV 50 "tables/Feed.tab" Feed
# total 957,000 lines
