CREATE OR ALTER PROCEDURE Kiosk.RetrieveMostPopularPlaceInCategory
   @CategoryId INT
AS

SELECT TOP(1)
	AVG(R.Rating)
FROM Kiosk.Category C
	INNER JOIN Kiosk.Place P ON P.CategoryId = C.CategoryId
WHERE C.CategoryId = @CategoryId
GO
