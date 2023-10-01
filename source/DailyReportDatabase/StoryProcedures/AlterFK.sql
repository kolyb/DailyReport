CREATE PROCEDURE [dbo].[AlterFK]
	@workLocationId int

	
AS
     BEGIN

ALTER TABLE Persons
ADD CONSTRAINT [FK_Person_Work]
FOREIGN KEY (WorkLocationId)
	REFERENCES WorkLocations (Id)
ON DELETE CASCADE ON UPDATE CASCADE



    End
