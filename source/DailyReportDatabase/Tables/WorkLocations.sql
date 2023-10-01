CREATE TABLE [dbo].[WorkLocations]
(
	[Id] int IDENTITY (1,1),
	[Description] nvarchar(max) NULL,
	[AdressWorkLocation] nvarchar(max) NULL,
	CONSTRAINT PK_guid PRIMARY KEY (Id),
)
