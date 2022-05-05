create or alter procedure Kiosk.SavePerson
	@PersonId int,
    @Name NVARCHAR(32),
	@Email NVARCHAR(64),
	@Password NVARCHAR(32)
as

MERGE Kiosk.Person P
USING
      (
         VALUES(@Name, @Email, @Password)
      ) S([Name], Email, [Password])
   ON S.Email = P.Email
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
   INSERT([Name], Email, [Password])
   VALUES(S.[Name], S.Email, S.[Password]);
GO
