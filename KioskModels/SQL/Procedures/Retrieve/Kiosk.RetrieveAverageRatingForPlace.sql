CREATE OR ALTER PROCEDURE Kiosk.RetrieveAverageRatingForPlace
   @PlaceId INT
AS

SELECT AVG(R.Rate)
FROM Kiosk.Place P
	INNER JOIN Kiosk.Rating R ON R.PlaceId = P.PlaceId
WHERE P.PlaceId = @PlaceId
GO
