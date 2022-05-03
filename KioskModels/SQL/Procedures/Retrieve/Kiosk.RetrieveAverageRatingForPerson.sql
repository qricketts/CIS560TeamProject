CREATE OR ALTER PROCEDURE Kiosk.RetrieveAverageRatingForPerson
   @PersonId INT
AS

SELECT AVG(R.Rate)
FROM Kiosk.Person P
	INNER JOIN Kiosk.Rating R ON R.PersonId = P.PersonId
WHERE P.PersonId = @PersonId
GO
