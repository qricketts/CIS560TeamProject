CREATE OR ALTER PROCEDURE Kiosk.FetchRating
   @RatingId INT
AS

select R.RatingId, R.Rate, R.PlaceId, R.PersonId
from Kiosk.Rating R
where R.RatingId = @RatingId
GO
