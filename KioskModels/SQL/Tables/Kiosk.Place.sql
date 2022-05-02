if object_id(N'Kiosk.Place') is null
begin
	create table Kiosk.Place
	(
		PlaceID int not null identity(1,1) primary key, 
		CategoryID int not null foreign key
			references Kiosk.Category(CategoryID),
		[Name] nvarchar(32) not null,
		[Address] nvarchar(128) not null,
		[Description] nvarchar(256) not null,
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())

		unique([Name], ZipCode)
	); 
end; 