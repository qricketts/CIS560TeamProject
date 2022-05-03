create or alter procedure Kiosk.SavePlace
    @CategoryId int,
    @Name NVARCHAR(32),
	@Address NVARCHAR(128),
	@Description NVARCHAR(256)
as

MERGE Kiosk.Place P
USING
      (
         VALUES(@CategoryId, @Name, @Address, @Description)
      ) S(CategoryId, [Name], [Address], [Description])
   ON S.[Address] = P.[Address]
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.[Name], S.[Address], S.[Description]
         INTERSECT
         SELECT P.[Name], P.[Address], P.[Description]
      ) THEN
   UPDATE
   SET
      CategoryId = S.CategoryId,
      [Name] = S.[Name],
      [Address] = s.[Address],
      [Description] = S.[Description],
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(CategoryId, [Name], [Address], [Description])
   VALUES(S.CategoryId, S.[Name], S.[Address], S.[Description]);
GO

