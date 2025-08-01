# Milestone 2

This project contains all the code used to creat Milestone 2 for Compx323-25A at the University of Waikato.

## Tasks
- Relational Schema - **Joel**
- Table Creation - **Joel / Dolf / Min Soe**
- Datasets (large & small) - **Dolf**
- Application - **Min Soe / Dolf / Joel**

## Files
- [zoo.sql](zoo.sql) Contains two sets of tables. `m2s` and `m2l`. These represent the tables for the small and large data sets.
- [small.sql](small.sql) Contains the small, realistic datasets.
- [large/](./large) - Contains the CSV files that hold the data for the large data sets. *Removed from the final comit to save space*
- [app/](./app) - Contains the Application.
- [gen/](./gen) - Contains the data generation code.
- [mongo/](./mongo) - Contains all the .json file to implement the zoo database in MongoDB.
- [createImportSQL.sh](createImportSQL.sh) - If placed inside the directly of your csv files, it will generate an import sql file to load all the files into the database. 

### createImportSQL
Run the file inside of the directory containing your csv files. This will create an sql file that will import all of the data for you. (As long as your tables already exist).
#### Linux

Open a terminal window and navigate to the directory containing the csv files and the script.

Run `./createImportSQL.sh` and bam! Your file is ready.

#### Windows

Open the file explorer and navigate to the folder containing the csv files and script. Right click on an empty spot in the folder. Select 'More Options' -> 'Git Bash' (NOT Git cmd!). A terminal window should open up. Run `./createImportSQL.sh`. This will create a new import sql file in that folder. 

