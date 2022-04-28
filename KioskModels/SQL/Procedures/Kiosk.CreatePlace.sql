CREATE OR ALTER PROCEDURE Kiosk.CreatePlace
   @Name NVARCHAR(32),
   @Address NVARCHAR(128),
   @Description NVARCHAR(256),
   @PlaceId INT OUTPUT
AS

INSERT Place.Place(Name, Address, Description)
VALUES(@Name, @Address, @Description);

SET @PlaceId = SCOPE_IDENTITY();
GO
