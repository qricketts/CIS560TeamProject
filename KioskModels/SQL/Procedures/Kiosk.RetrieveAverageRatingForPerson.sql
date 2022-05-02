CREATE OR ALTER PROCEDURE Kiosk.RetrieveAverageRatingForPerson
   @PersonId INT
AS

SELECT AVG(R.Rating)
FROM Kiosk.Person P
	INNER JOIN Kiosk.Rating R ON R.PersonId = P.PersonId
WHERE P.PersonId = @PersonId
GO
