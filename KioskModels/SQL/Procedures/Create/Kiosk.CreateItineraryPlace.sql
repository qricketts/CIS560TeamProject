CREATE OR ALTER PROCEDURE Kiosk.CreateItineraryPlace
   @ItineraryId INT,
   @PlaceId INT 
AS

INSERT Kiosk.ItineraryPlace(ItineraryId, PlaceId)
VALUES(@ItineraryId, @PlaceId);

SET @ItineraryPlaceId = SCOPE_IDENTITY();
GO
