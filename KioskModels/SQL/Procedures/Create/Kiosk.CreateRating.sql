CREATE OR ALTER PROCEDURE Kiosk.CreateRating
   @Rate int ,
   @PlaceId int, 
   @PersonId int
AS

INSERT Kiosk.Rating(Rate, PlaceId, PersonId)
VALUES(@Rate, @PlaceId, @PersonId);

SET @RatingId = SCOPE_IDENTITY();
GO

