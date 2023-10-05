ALTER TABLE dbo.[Persons]
ADD CONSTRAINT FK_Position_Person FOREIGN KEY (PositionId)     
    REFERENCES dbo.Positions (Id)
ON UPDATE CASCADE