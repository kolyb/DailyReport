CREATE TABLE [dbo].[Persons]
(
	[Id] int IDENTITY(1,1),
	[Birthday] nvarchar(120) NULL,
	[FirstName] nvarchar(120) NULL,
	[MiddleName] nvarchar(120) NULL,
	[LastName] nvarchar(120) NULL,
	[WorkLocationId] int NOT NULL,
	--[WorkLocation] nvarchar(120) NULL,
	[Position] nvarchar(120) NULL,
	[PhoneNumber] nvarchar(120) NULL,
	CONSTRAINT PK_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Person_WorkLocation FOREIGN KEY (WorkLocationId)
	REFERENCES WorkLocations (Id)
    ON UPDATE CASCADE
)
