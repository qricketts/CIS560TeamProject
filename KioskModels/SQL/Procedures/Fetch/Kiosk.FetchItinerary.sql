CREATE OR ALTER PROCEDURE Kiosk.FetchItinerary
   @ItineraryId INT 
AS

select I.ItineraryId
from Kiosk.Itinerary I
where I.ItineraryId = @ItineraryId; 
GO
