CREATE TABLE [dbo].[Events]
(
	[Id] int primary key identity,
	[Description] nvarchar(max) NULL,
	[EventTime] DateTime NULL
)
