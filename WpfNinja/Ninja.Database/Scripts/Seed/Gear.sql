MERGE INTO dbo.Gear AS Target  
USING (values 
	(1, 'Helmet of Strength', 200, 10, 0, 5, 1),
	(2, 'Drinking Cap', 20, 0, -50, 0, 1),
	(3, 'Swifty Hat', 250, 0, 0, 20, 1),
	(4, 'Hardcore Shoulders', 200, 15, 0, -5, 2),
	(5, 'Paper Shoulders', 20, -5, 0, 5, 2),
	(6, 'Cape of God', 400, 15, 15, 15, 2),
	(7, 'Arnold 1975 Chest', 400, 40, 0, 0, 3),
	(8, 'Magical Chest', 200, 0, -50, 0, 3),
	(9, 'Agility Chest', 250, 0, 5, 20, 3),
	(10, 'WWE Belt', 200, 25, 0, 0, 4),
	(11, 'Black Belt', 300, 15, 10, 5, 4),
	(12, 'Beer Belt', 200, 10, 0, -5, 4),
	(13, 'Girly Dress', 200, 0, 35, -5, 5),
	(14, 'Thight Pants', 320, 0, -5, 30, 5),
	(15, 'Metal Pants', 200, 20, 0, -5, 5),
	(16, 'Air Boots', 400, 0, 0, 50, 6),
	(17, 'Sandals with Socks', 20, 0, -50, 0, 6),
	(18, 'Armor Boots', 200, 10, 10, -5, 6)
) AS Source (Id, Name, GoldValue, Strength, Intelligence, Agility, CategoryId)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, GoldValue, Strength, Intelligence, Agility, CategoryId)  
	VALUES (Id, Name, GoldValue, Strength, Intelligence, Agility, CategoryId) 
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		GoldValue = Source.GoldValue,
		Strength = Source.Strength,
		Intelligence = Source.Intelligence,
		Agility = Source.Agility,
		CategoryId = Source.CategoryId;