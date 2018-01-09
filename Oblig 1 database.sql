-- CREATE DATABASE ColorRaves;
-- USE ColorRaves;

-- CREATE TABLE Player(Player_Name VARCHAR(40), Player_ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY);
-- CREATE TABLE Inventory(Item_Name VARCHAR(40), Item_ID SMALLINT PRIMARY KEY, player INT UNSIGNED NOT NULL, FOREIGN KEY(player) REFERENCES Player (Player_ID) ON UPDATE CASCADE ON DELETE CASCADE);
-- CREATE TABLE gLevel( nrOfMonsters TINYINT, levelName VARCHAR(40), level_ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY);
-- CREATE TABLE GAME(game_ID INT UNSIGNED NOT NULL AUTO_INCREMENT, player INT UNSIGNED NOT NULL, FOREIGN KEY(player) REFERENCES Player (Player_ID) ON UPDATE CASCADE ON DELETE CASCADE, PRIMARY KEY(game_ID, player));

-- ALTER TABLE GAME ADD COLUMN score INT;

-- ALTER TABLE Player ADD COLUMN state ENUM('active', 'inactive');

-- ALTER TABLE Inventory ADD COLUMN item_type ENUM('weapon','power up', 'other');

-- ALTER TABLE Player ADD COLUMN HighScore INT;

-- INSERT INTO gLevel VALUES(6, 'level 1',NULL),(10,'level 2', NULL),(2,'level 3', NULL),(25,'level 4',NULL);

-- INSERT INTO PLAYER VALUES ('Adrian',NULL,'inactive',76), ('Oda',NULL,'inactive',80), ('Berd',NULL,'inactive',64), ('Emma',NULL,'active',NULL);

-- INSERT INTO Inventory VALUES 
-- 	('Turbo Boost',NULL,NULL, 'power up'), 
-- 	('Ray Gun',NULL,1, 'weapon'), 
--     ('Shoes',NULL,1, 'other'), 
--     ('Potion',NULL,3, 'power up'), 
--     ('Wave Grenade',NULL,2, 'weapon'),
--     ('car',NULL,4, 'other');

-- INSERT INTO GAME VALUES
-- 	(NULL, 1, 43)
-- 	(NULL, 2, 50),
--     (NULL, 2, 20),
--     (NULL, 2, 80),
--     (NULL, 3, 16),
--     (NULL, 3, 64),
--     (NULL, 4, 33),
--     (NULL, 4, 33),
--     (NULL, 1, 76);

-- UPDATE PLAYER SET HighScore = (SELECT max(score)  FROM GAME WHERE player = 4) where Player_ID = 4;

-- SELECT  Game.score, player.Player_Name FROM GAME LEFT JOIN player ON game.player = player.Player_ID ORDER BY score DESC;

-- SELECT DISTINCT Game.score, player.Player_Name FROM GAME LEFT JOIN player ON game.player = player.Player_ID ORDER BY score DESC;

-- SELECT Player_Name, HighScore FROM Player ORDER BY HighScore DESC;

-- DELETE FROM Player where Player_ID = 4;

