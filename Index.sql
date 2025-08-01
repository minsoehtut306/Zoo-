
-- Query 1: Point Query on primary key (aid)
EXPLAIN PLAN FOR
SELECT * FROM M2L_ANIMAL WHERE aid = 352;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

-- Query 2: Range Query on weight
EXPLAIN PLAN FOR
SELECT * FROM M2L_ANIMAL WHERE weight BETWEEN 300 AND 500;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

-- Query 3: Join with filter on staffid
EXPLAIN PLAN FOR
SELECT f.*, a.name
FROM M2L_FEED f
JOIN M2L_ANIMAL a ON f.animalid = a.aid
WHERE f.staffid = 100;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

-- B-Tree indexes for point and range query optimisation
CREATE INDEX idx_l_animal_weight ON M2L_ANIMAL(weight);
CREATE INDEX idx_l_feed_staffid ON M2L_FEED(staffid);
CREATE INDEX idx_l_feed_animalid ON M2L_FEED(animalid);

-- Query 1: Point Query
EXPLAIN PLAN FOR
SELECT * FROM M2L_ANIMAL WHERE aid = 352;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

-- Query 2: Range Query
EXPLAIN PLAN FOR
SELECT * FROM M2L_ANIMAL WHERE weight BETWEEN 300 AND 500;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

-- Query 3: Join with filter
EXPLAIN PLAN FOR
SELECT f.*, a.name
FROM M2L_FEED f
JOIN M2L_ANIMAL a ON f.animalid = a.aid
WHERE f.staffid = 100;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);
