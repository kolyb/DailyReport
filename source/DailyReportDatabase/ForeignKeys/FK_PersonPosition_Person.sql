ALTER TABLE dbo.[Persons]
ADD CONSTRAINT FK_PersonPosition_Person FOREIGN KEY (PositionId)     
    REFERENCES dbo.PersonPositions (Id)
ON UPDATE CASCADE