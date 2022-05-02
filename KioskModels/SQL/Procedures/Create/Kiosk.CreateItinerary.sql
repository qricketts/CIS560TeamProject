CREATE OR ALTER PROCEDURE Kiosk.CreateItinerary
   @ItineraryId INT OUTPUT
AS

INSERT Kiosk.Itinerary(ItineraryId)
VALUES(@ItineraryId);

SET @ItineraryId = SCOPE_IDENTITY();
GO
