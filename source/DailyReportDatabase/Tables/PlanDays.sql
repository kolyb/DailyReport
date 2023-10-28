CREATE TABLE [dbo].[PlanDays]
(
	[Id] int primary key identity,
	[Day] date,
	[UserName] nvarchar(120) NOT NULL,
)
