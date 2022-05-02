CREATE OR ALTER PROCEDURE Kiosk.RetrievePeople
AS

SELECT P.PersonId, P.[Name], P.Email, P.[Password]
FROM Kiosk.Person P
GO
