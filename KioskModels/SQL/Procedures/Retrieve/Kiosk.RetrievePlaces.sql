CREATE OR ALTER PROCEDURE Kiosk.RetrievePlaces
AS

SELECT P.PlaceId, P.CategoryId, P.[Name], P.[Address], P.[Description]
FROM Kiosk.Place P
GO
