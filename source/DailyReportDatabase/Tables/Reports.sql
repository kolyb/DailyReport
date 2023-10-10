CREATE TABLE [dbo].[Reports]
(
	[Id] int primary key identity,
	--[UserIdentityId] int NOT NULL,
	[PersonId] int NOT NULL,
	[PlanDateId] int NOT NULL, 
	[Time] time NULL,	
)
