--Import Files
LOAD m2s_SpeciesGroup C:/Users/jc550/source/repos/milestone2_compx323/gen/small/SpeciesGroup.csv;
LOAD m2s_Zone C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Zone.csv;
LOAD m2s_Enclosure C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Enclosure.csv;
LOAD m2s_Species C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Species.csv;
LOAD m2s_Staff C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Staff.csv;
LOAD m2s_Animal C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Animal.csv;
LOAD m2s_Oversees C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Oversees.csv;
LOAD m2s_Care C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Care.csv;
LOAD m2s_Feed C:/Users/jc550/source/repos/milestone2_compx323/gen/small/Feed.csv;
 
--See the if the data was imported
SELECT * FROM m2s_SpeciesGroup FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Zone FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Enclosure FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Species FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Staff FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Animal FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Oversees FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Care FETCH FIRST 5 ROWS ONLY;
SELECT * FROM m2s_Feed FETCH FIRST 5 ROWS ONLY;
