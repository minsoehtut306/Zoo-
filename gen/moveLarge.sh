#!/bin/bash

# This removed the large file and then moves the large file from this directory into the root directory of the git file

rm -r ../large/
mv large/ ..
cp ../createImportSQL.sh ../large/
