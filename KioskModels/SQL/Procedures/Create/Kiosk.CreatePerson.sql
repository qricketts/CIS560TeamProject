CREATE OR ALTER PROCEDURE Kiosk.CreatePerson
   @Name NVARCHAR(32),
   @Email NVARCHAR(128),
   @Password NVARCHAR(128)
AS

INSERT Kiosk.Person([Name], Email, [Password])
VALUES(@Name, @Email, @Password);

SET @PersonId = SCOPE_IDENTITY();
GO
