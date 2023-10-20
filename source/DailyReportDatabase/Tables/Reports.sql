CREATE TABLE [dbo].[Reports]
(
	[Id] int primary key identity,
	--[UserIdentityId] int NOT NULL,
	[PersonId] int NOT NULL,
	[ReportDayId] int NOT NULL, 
	[Time] time NULL,	
)
