CREATE OR ALTER PROCEDURE Kiosk.CreateRating
   @Rate int ,
   @PlaceId int, 
   @PersonId int,
   @RatingId INT OUTPUT
AS

INSERT Kiosk.Rating(Rate, PlaceId, PersonId)
VALUES(@Rate, @PlaceId, @PersonId);

SET @RatingId = SCOPE_IDENTITY();
GO

