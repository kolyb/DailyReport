CREATE TABLE [dbo].[Plans]
(
	[Id] int primary key identity,
	[PersonId] int NULL,
	[PlanDayId] int NOT NULL, 
	[StartTime] time NULL,
	[FinishTime] time NULL,
	[IntervalTime] time NULL,
)
