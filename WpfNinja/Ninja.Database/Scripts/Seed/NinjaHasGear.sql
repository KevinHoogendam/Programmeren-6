MERGE INTO dbo.NinjaHasGear AS Target  
USING (values 
	(1, 2),
	(1, 5),
	(1, 7),
	(1, 12),
	(1, 13),
	(1, 17),
	(2, 2),
	(2, 4),
	(2, 7),
	(2, 12),
	(2, 14),
	(2, 17)
) AS Source (NinjaId, GearId)  
ON Target.NinjaId = Source.NinjaId  
and Target.GearId = Source.GearId
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (NinjaId, GearId)  
	VALUES (NinjaId, GearId);