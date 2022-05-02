CREATE OR ALTER PROCEDURE Kiosk.RetrieveItineraryPlaces
AS

SELECT I.ItineraryPlaceId, I.ItineraryId, I.PlaceId
FROM Kiosk.ItineraryPlace I
GO
