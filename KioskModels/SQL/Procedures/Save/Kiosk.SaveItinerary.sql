create or alter procedure Kiosk.SaveItinerary
	@ItineraryId INT
as

MERGE Kiosk.Itinerary I
USING
      (
         VALUES(@ItineraryId)
      ) S(ItineraryId)
   ON S.ItineraryId = I.ItineraryId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.ItineraryId
         INTERSECT
         SELECT I.ItineraryId
      ) THEN
   UPDATE
   SET
      ItineraryId = S.ItineraryId,
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(ItineraryId)
   VALUES(S.ItineraryId);
GO


