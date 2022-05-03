CREATE OR ALTER PROCEDURE Kiosk.RetrieveRatings
AS

SELECT R.RatingId, R.Rate, R.PlaceId, R.PersonId
FROM Kiosk.Rating R
GO
