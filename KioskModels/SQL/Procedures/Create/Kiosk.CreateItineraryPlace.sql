CREATE OR ALTER PROCEDURE Kiosk.CreateItineraryPlace
   @ItineraryPlaceId INT OUTPUT,
   @ItineraryId INT,
   @PlaceId INT 
AS

INSERT Kiosk.ItineraryPlace(ItineraryPlaceId, ItineraryId, PlaceId)
VALUES(@ItineraryPlaceId, @ItineraryId, @PlaceId);

SET @ItineraryPlaceId = SCOPE_IDENTITY();
GO
