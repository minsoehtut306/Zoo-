#!/bin/bash


java parseArgs 1 -v 10 -i 5 -d -t -f "csv/test.csv" 1 -o 5 2 -I 0 -V 3 -F "csv/test.csv" 2 -T -h 6 -e -b -g


java MakeCSV $1 tables/1.tab out

