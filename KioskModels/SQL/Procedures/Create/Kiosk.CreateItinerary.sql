CREATE OR ALTER PROCEDURE Kiosk.CreateItinerary
   @PersonId int
AS

INSERT Kiosk.Itinerary(PersonId)
VALUES(@PersonId);

SET @ItineraryId = SCOPE_IDENTITY();
GO
