CREATE PROCEDURE [dbo].[DeleteFK]
	@workLocationId int

	
AS
     BEGIN

ALTER TABLE Persons
DROP CONSTRAINT FK_Person_WorkLocation
	 DELETE from [dbo].Persons
	 Where WorkLocationId=@workLocationId


    End
