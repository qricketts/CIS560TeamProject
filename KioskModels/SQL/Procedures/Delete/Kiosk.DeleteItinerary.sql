create or alter PROCEDURE Kiosk.DeleteItinerary
   @ItineraryId INT 
AS

delete Kiosk.Itinerary
where ItineraryId = @ItineraryId; 

GO
