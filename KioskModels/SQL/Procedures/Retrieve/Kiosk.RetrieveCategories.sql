CREATE OR ALTER PROCEDURE Kiosk.RetrieveCategories
AS

SELECT C.CategoryId, C.[Name]
FROM Kiosk.Category C
GO

