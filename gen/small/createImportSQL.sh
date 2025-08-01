#!/bin/bash

# @author Dolf ten Have
# @date 02/05/2025
# This file generates all required sql files to import the csv data into Oracle DB


tables=("SpeciesGroup" "Zone" "Enclosure" "Species" "Staff" "Animal" "Oversees" "Care" "Feed");
prefix="m2l"
path="$(pwd -W)"
echo "--Import Files" >> load_data.sql
for table in "${tables[@]}"; do
	echo "LOAD ${prefix}_${table} ${path}/${table}.csv;" >> load_data.sql
done
echo " " >> load_data.sql
echo "--See the if the data was imported" >> load_data.sql
for table in "${tables[@]}"; do
	echo "--SELECT * FROM ${prefix}_${table} FETCH FIRST 5 ROWS ONLY;" >> load_data.sql
done

