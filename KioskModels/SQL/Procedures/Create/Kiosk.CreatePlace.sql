CREATE OR ALTER PROCEDURE Kiosk.CreatePlace
   @Name NVARCHAR(32),
   @CategoryId int,
   @Address NVARCHAR(128),
   @Description NVARCHAR(256)
AS

INSERT Kiosk.Place([Name], CategoryId, [Address], [Description])
VALUES(@Name, @CategoryId, @Address, @Description);

SET @PlaceId = SCOPE_IDENTITY();
GO
