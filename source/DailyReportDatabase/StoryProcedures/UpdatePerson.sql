CREATE PROCEDURE [dbo].[UpdatePerson]
    @personId int,
	--@workLocationId int,
	--@userIdentityId int,
	@birthday nvarchar (120),
	@firstName nvarchar (120),
	@middleName nvarchar (120),
	@lastName nvarchar (120),
	@workLocation nvarchar (120),
	@positionWorkLocation nvarchar (120),
	@phoneNumber nvarchar (120)
	
	
	
AS
Begin
     BEGIN
	       Update Persons
		   set Persons.Birthday = @birthday, Persons.FirstName = @firstName,
		   Persons.MiddleName = @middleName, Persons.LastName = @lastName,
		   --Persons.WorkLocationId = @workLocationId,
		   Persons.WorkLocation = @workLocation,
		   Persons.PositionWorkLocation = @positionWorkLocation, Persons.PhoneNumber = @phoneNumber
		   --Persons.UserIdentityId = @userIdentityId
		   Where Persons.Id = @personId
	 end
End
