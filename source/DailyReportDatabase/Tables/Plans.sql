CREATE TABLE [dbo].[Plans]
(
	[Id] int primary key identity,
	--[UserIdentityId] int NOT NULL,
	[PersonId] int NULL,
	[PlanDayId] int NOT NULL, 
	[StartTime] datetime NULL,
	[FinishTime] datetime NULL,
	[IntervalTime] time NULL,
)
