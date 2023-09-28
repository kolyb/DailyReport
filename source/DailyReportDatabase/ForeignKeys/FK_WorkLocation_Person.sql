ALTER TABLE dbo.[WorkLocations]
ADD CONSTRAINT FK_WorkLocation_Person FOREIGN KEY (PersonId)     
    REFERENCES dbo.Persons(Id)
