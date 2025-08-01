#!/bin/bash

java parseArgs testFiles col1 col2 col3 -f test.csv 1 -f test.csv 2 -f test.csv 3
java MakeCSV 20 tables/testFiles.tab out_testFile
