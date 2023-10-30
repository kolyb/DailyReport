CREATE TABLE [dbo].[Reports]
(
	[Id] int primary key identity,
	[PersonId] int NOT NULL,
	[ReportDayId] int NOT NULL, 
	[StartTime] time NULL,
	[FinishTime] time NULL,
	[IntervalTime] time NULL,	
)
