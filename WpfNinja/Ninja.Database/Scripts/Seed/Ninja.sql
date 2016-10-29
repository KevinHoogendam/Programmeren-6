MERGE INTO dbo.Ninja AS Target  
USING (values 
	(1, 'Kevin', 2000),
	(2, 'Roel', 2000)
) AS Source (Id, Name, Gold)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, Gold)  
	VALUES (Id, Name, Gold)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Gold = Source.Gold;