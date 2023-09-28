CREATE TABLE [dbo].[WorkLocations]
(
	[Id] int primary key identity,
	[PersonId] int NOT NULL,
	[Description] nvarchar(max) NULL,
	[AdressWorkLocation] nvarchar(max) NULL
)
