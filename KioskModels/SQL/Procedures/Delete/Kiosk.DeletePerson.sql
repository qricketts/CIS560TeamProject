create or alter PROCEDURE Kiosk.DeletePerson
   @PersonId INT OUTPUT
AS

delete Kiosk.Person
where PersonId = @PersonId; 

GO
