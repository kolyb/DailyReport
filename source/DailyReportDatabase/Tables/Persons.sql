CREATE TABLE [dbo].[Persons]
(
	[Id] int primary key identity,
    [UserIdentityEmail] nvarchar(120) NOT NULL,
	[Birthday] nvarchar(120) NULL,
	[FirstName] nvarchar(120) NULL,
	[MiddleName] nvarchar(120) NULL,
	[LastName] nvarchar(120) NULL,
    [WorkplaceId] int NULL,
	[PositionId] int NOT NULL,
	[ProfessionId] int NOT NULL,
	[PhoneNumber] nvarchar(120) NULL
)
