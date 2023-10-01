CREATE PROCEDURE [dbo].[CreateFK]
	@workLocationId int

	
AS
     BEGIN

ALTER TABLE Persons
ADD CONSTRAINT [FK_Person_WorkLocation]
FOREIGN KEY (WorkLocationId)
REFERENCES WorkLocations (Id)

	 


    End
