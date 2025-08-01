-- still work in progress 
SELECT *
FROM m2l_Feed
WHERE staffID = 1 AND animalID = 1;

SELECT *
FROM m2l_Animal
WHERE weight BETWEEN 200 AND 300;

EXPLAIN PLAN FOR SELECT * FROM m2l_Animal WHERE aid = 500123;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

CREATE INDEX idx_animal_weight ON m2l_Animal(weight);

-- Create a hash cluster 
CREATE CLUSTER animal_cluster (aid NUMBER)
    HASHKEYS 100000;

-- Move table into the cluster
CREATE TABLE m2l_Animal_clustered (
    aid NUMBER PRIMARY KEY,
) CLUSTER animal_cluster(aid);

-- Populate it with data
INSERT INTO m2l_Animal_clustered SELECT * FROM m2l_Animal;

-- Re-run the same point query on the new table:
EXPLAIN PLAN FOR SELECT * FROM m2l_Animal_clustered WHERE aid = 500123;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);
