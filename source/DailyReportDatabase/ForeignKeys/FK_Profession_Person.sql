ALTER TABLE dbo.[Persons]
ADD CONSTRAINT FK_Profession_Person FOREIGN KEY (ProfessionId)     
    REFERENCES dbo.Professions (Id)
ON UPDATE CASCADE