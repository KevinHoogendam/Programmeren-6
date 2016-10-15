CREATE TABLE [dbo].[Gear]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(30) NOT NULL, 
    [GoldValue] INT NOT NULL, 
    [Strength] INT NULL, 
    [Intelligence] INT NULL, 
    [agility] INT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Gear_Category] FOREIGN KEY ([CategoryId]) REFERENCES dbo.Category ([Id])
)
