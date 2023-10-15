CREATE TABLE [dbo].[Plans]
(
	[Id] int primary key identity,
	--[UserIdentityId] int NOT NULL,
	[PersonId] int NULL,
	[PlanDateId] int NOT NULL, 
	[PlanTime] time NULL,	
)
