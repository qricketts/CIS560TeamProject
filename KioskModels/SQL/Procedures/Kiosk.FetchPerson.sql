CREATE OR ALTER PROCEDURE Kiosk.FetchPerson
   @PersonId INT 
AS

select P.PersonId, P.[Name], P.Email, P.[Password]
from Kiosk.Person P 
where P.PersonId = @PersonId; 

GO
