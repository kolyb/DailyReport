﻿ALTER TABLE dbo.[Reports]
ADD CONSTRAINT FK_Person_Report FOREIGN KEY (PersonId)     
    REFERENCES dbo.Persons (Id)
ON UPDATE CASCADE
ON DELETE CASCADE