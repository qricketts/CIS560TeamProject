create or alter procedure Kiosk.SavePerson
	@PersonId INT,
    @Name NVARCHAR(32),
	@Email NVARCHAR(64),
	@Password NVARCHAR(32)
as

MERGE Kiosk.Person P
USING
      (
         VALUES(@PersonId, @Name, @Email, @Password)
      ) S(PersonId, [Name], Email, [Password])
   ON S.PersonId = P.PersonId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.Email, S.[Password]
         INTERSECT
         SELECT  P.[Name], P.Email, P.[Password]
      ) THEN
   UPDATE
   SET
      [Name] = S.[Name],
      Email = S.Email,
      [Password] = S.[Password],
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(PersonId, [Name], Email, [Password])
   VALUES(S.PersonId, S.[Name], S.Email, S.[Password]);
GO
