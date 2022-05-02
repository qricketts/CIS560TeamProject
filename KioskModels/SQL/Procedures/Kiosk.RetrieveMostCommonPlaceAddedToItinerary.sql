CREATE OR ALTER PROCEDURE Kiosk.RetrieveMostCommonPlaceAddedToItinerary
AS

SELECT TOP(1)
	COUNT([IP].PlaceId)
FROM Kiosk.Itinerary I
	INNER JOIN Kiosk.ItineraryPlace [IP] ON [IP].ItineraryId = I.ItineraryId
GO
