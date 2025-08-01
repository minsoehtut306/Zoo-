#!/bin/bash

# This file tests fully all the data types of parseArgs

java parseArgs test -v 1 -i 2 -d -t -f "file_testPath" 1 -o 3 3 -I 4 -V 5 -F "seqFile_testPath" 1 -T -h 6 -e -b -g -f "file_testPath" 2 -f "file_testPath" 3
