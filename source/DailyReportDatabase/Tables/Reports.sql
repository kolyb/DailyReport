CREATE TABLE [dbo].[Reports]
(
	[Id] int primary key identity,
	[PersonId] int NOT NULL,
	[ReportDayId] int NOT NULL, 
	[StartTime] datetime NULL,
	[FinishTime] datetime NULL,
	[IntervalTime] time NULL,	
)
