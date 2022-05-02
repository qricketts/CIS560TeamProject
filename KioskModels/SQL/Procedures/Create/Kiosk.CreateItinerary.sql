CREATE OR ALTER PROCEDURE Kiosk.CreateItinerary
   @ItineraryId INT OUTPUT,
   @PersonId int
AS

INSERT Kiosk.Itinerary(ItineraryId, PersonId)
VALUES(@ItineraryId, @PersonId);

SET @ItineraryId = SCOPE_IDENTITY();
GO
