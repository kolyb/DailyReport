CREATE TABLE [dbo].[WorkLocations]
(
	[Id] int IDENTITY (1,1),
	[Description] nvarchar(120) NULL,
	[AdressCity] nvarchar(120) NULL,
	[AdressStreet] nvarchar(120) NULL,
	[AdressHouse] nvarchar(120) NULL,
	CONSTRAINT PK_guid PRIMARY KEY (Id),
)
