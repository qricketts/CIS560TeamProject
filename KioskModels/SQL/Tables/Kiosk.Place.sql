if object_id(N'Kiosk.Place') is null
begin
	create table Kiosk.Place
	(
		PlaceID int not null identity(1,1) primary key, 
		[Name] nvarchar(64) not null,
		CategoryID int not null foreign key
			references Kiosk.Category(CategoryID),
		[Address] nvarchar(64) not null, 
		City nvarchar(64) not null, 
		[State] nvarchar(2) not null, 
		ZipCode nvarchar(5) not null,
		MapLink nvarchar(128) not null, 
		Picture nvarchar(128), 
		[Description] nvarchar(256) not null,
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())

		unique([Name], ZipCode)
	); 
end; 