﻿ALTER TABLE dbo.[Plans]
ADD CONSTRAINT FK_Person_Plan FOREIGN KEY (PersonId)     
    REFERENCES dbo.Persons (Id)
ON UPDATE CASCADE
ON DELETE CASCADE