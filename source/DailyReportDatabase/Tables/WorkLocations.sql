CREATE TABLE [dbo].[WorkLocations]
(
	[Id] int primary key identity,
	[Description] nvarchar(120) NULL,
	[AdressCity] nvarchar(120) NULL,
	[AdressStreet] nvarchar(120) NULL,
	[AdressHouse] nvarchar(120) NULL,
)
