MERGE INTO dbo.Category AS Target  
USING (values 
	(1, 'Head'),
	(2, 'Shoulders'),
	(3, 'Chest'),
	(4, 'Belt'),
	(5, 'Legs'),
	(6, 'Boots')
) AS Source (Id, Name)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name)  
	VALUES (Id, Name)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name;