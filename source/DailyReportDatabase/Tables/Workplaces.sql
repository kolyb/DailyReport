CREATE TABLE [dbo].[Workplaces]
(
	[Id] int primary key identity,
	[UserIdentityEmail] nvarchar(120) NULL,
	[Description] nvarchar(120) NULL,
	[AdressCity] nvarchar(120) NULL,
	[AdressStreet] nvarchar(120) NULL,
	[AdressHouse] nvarchar(120) NULL,
)
