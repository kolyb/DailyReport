
ALTER TABLE dbo.[Persons]
ADD CONSTRAINT FK_WorkLocation_Person FOREIGN KEY (WorkLocationId)     
    REFERENCES dbo.WorkLocations (Id)
ON UPDATE CASCADE

