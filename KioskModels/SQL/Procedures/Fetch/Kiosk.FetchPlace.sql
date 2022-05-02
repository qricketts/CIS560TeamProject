CREATE OR ALTER PROCEDURE Kiosk.FetchPlace
   @PlaceId INT
AS

select P.PlaceId, P.[Name], P.[Address], P.[Description]
from Kiosk.Place P
where P.PlaceId = @PlaceId;

GO
