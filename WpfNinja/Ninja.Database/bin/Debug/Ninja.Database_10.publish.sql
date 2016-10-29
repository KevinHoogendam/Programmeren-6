﻿/*
Deployment script for NinjaDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "NinjaDb"
:setvar DefaultFilePrefix "NinjaDb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

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
	INSERT (Id, Name, Gold)  
	VALUES (Id, Name, Gold)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Gold = Source.Gold;
--:r .\Seed\NinjaHasGear.sql
GO

GO
PRINT N'Update complete.';


GO
