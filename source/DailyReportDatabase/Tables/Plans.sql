CREATE TABLE [dbo].[Plans]
(
	[Id] int primary key identity,
	[PersonId] int NULL,
	[PlanDayId] int NOT NULL, 
	[StartTime] datetime NULL,
	[FinishTime] datetime NULL,
	[IntervalTime] time NULL,
)
