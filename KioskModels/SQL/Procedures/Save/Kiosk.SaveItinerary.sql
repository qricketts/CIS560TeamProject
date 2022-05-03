create or alter procedure Kiosk.SaveItinerary
	@PersonId INT
as

MERGE Kiosk.Itinerary I
USING
      (
         VALUES(@PersonId)
      ) S(PersonId)
   ON S.PersonId = I.PersonId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.PersonId
         INTERSECT
         SELECT I.PersonId
      ) THEN
   UPDATE
   SET
      PersonId = S.PersonId,
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(PersonId)
   VALUES(S.PersonId);
GO


