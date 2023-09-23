CREATE TABLE [dbo].[Persons]
(
	[Id] int primary key identity,
	[Birthday] nvarchar(120) NULL,
	[FirstName] nvarchar(120) NULL,
	[MiddleName] nvarchar(120) NULL,
	[LastName] nvarchar(120) NULL,
	[WorkLocationId] int NOT NULL,
	[WorkLocation] nvarchar(120) NULL,
	[PositionWorkLocation] nvarchar(120) NULL,
	[UserIdentityId] int NOT NULL,
	[EventId] int NOT NULL,
	[PhoneNumber] nvarchar(120) NULL,
	
)
