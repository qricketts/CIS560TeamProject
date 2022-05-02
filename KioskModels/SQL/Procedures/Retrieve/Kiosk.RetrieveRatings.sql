CREATE OR ALTER PROCEDURE Kiosk.RetrieveRatings
AS

SELECT R.RatingId, R.PlaceId, R.PersonId
FROM Kiosk.Rating R
GO
