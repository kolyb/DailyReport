CREATE TABLE [dbo].[Plans]
(
	[Id] int primary key identity,
	--[UserIdentityId] int NOT NULL,
	[PersonId] int NOT NULL,
	[PlanDateId] int NOT NULL, 
	[PlanTime] datetime NULL,	
)
