create or alter procedure Kiosk.SaveItineraryPlace
    @ItineraryId INT,
    @PlaceId INT 
as

MERGE Kiosk.ItineraryPlace I
USING
      (
         VALUES(@ItineraryId, @PlaceId)
      ) S(ItineraryId, PlaceId)
   ON S.ItineraryId = I.ItineraryId and S.PlaceId = I.PlaceId 
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.ItineraryId, S.PlaceId
         INTERSECT
         SELECT I.ItineraryId, I.PlaceId
      ) THEN
   UPDATE
   SET
      ItineraryId = S.ItineraryId,
	  PlaceId = S.PlaceId,
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(ItineraryId, PlaceId)
   VALUES(S.ItineraryId, S.PlaceId);
GO