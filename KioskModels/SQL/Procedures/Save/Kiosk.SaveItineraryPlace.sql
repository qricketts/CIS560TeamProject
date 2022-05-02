create or alter procedure Kiosk.SaveItineraryPlace
    @ItineraryPlaceId INT OUTPUT,
    @ItineraryId INT,
    @PlaceId INT 
as

MERGE Kiosk.ItineraryPlace I
USING
      (
         VALUES(@ItineraryPlaceId, @ItineraryId, @PlaceId)
      ) S(ItineraryPlaceId, ItineraryId, PlaceId)
   ON S.ItineraryPlaceId = I.ItineraryPlaceId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.ItineraryPlaceId, S.ItinearyId, S.PlaceId
         INTERSECT
         SELECT I.ItineraryPlaceId, I.ItineraryId, I.PlaceId
      ) THEN
   UPDATE
   SET
      ItineraryPlaceId = S.ItineraryPlaceId,
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(ItineraryPlaceId, ItineraryId, PlaceId)
   VALUES(S.ItineraryPlaceId, S.ItinearyId, S.PlaceId);
GO