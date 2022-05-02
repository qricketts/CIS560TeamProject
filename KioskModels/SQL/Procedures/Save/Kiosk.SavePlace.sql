create or alter procedure Kiosk.SavePlace
	@PlaceId INT,
    @CategoryId int,
    @Name NVARCHAR(32),
	@Address NVARCHAR(128),
	@Description NVARCHAR(256)
as

MERGE Kiosk.Place P
USING
      (
         VALUES(@PlaceId, @CategoryId, @Name, @Address, @Description)
      ) S(PlaceId, CategoryId, [Name], [Address], [Description])
   ON S.PlaceId = P.PlaceId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.CategoryId, S.[Name], S.[Address], S.[Description]
         INTERSECT
         SELECT  P.CategoryId, P.[Name], P.[Address], P.[Description]
      ) THEN
   UPDATE
   SET
      CategoryId = S.CategoryId,
      [Name] = S.[Name],
      [Address] = s.[Address],
      [Description] = S.[Description],
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(PlaceId, CategoryId, [Name], [Address], [Description])
   VALUES(S.CategoryId, S.[Name], S.[Address], S.[Description]);
GO

