CREATE TABLE [dbo].[ReportDays]
(
	[Id] int primary key identity,
	[RecordDay] date,
	[UserName] nvarchar(120) NOT NULL,
)
