
ALTER TABLE dbo.[Persons]
ADD CONSTRAINT FK_Workplace_Person FOREIGN KEY (WorkplaceId)     
    REFERENCES dbo.Workplaces (Id)
ON UPDATE CASCADE
ON DELETE CASCADE

