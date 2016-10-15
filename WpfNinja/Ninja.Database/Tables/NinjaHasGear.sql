CREATE TABLE [dbo].[NinjaHasGear]
(
	[NinjaId] INT NOT NULL ,
	[GearId] INT NOT NULL,
    PRIMARY KEY ([NinjaId], [GearId]),
	CONSTRAINT FK_NinjaHasGear_Ninja FOREIGN KEY ([NinjaId]) REFERENCES dbo.Ninja ([Id]),
	CONSTRAINT FK_NinjaHasGear_Gear FOREIGN KEY ([GearId]) REFERENCES dbo.Gear ([Id])
)
