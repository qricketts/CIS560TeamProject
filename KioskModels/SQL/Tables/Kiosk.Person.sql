if object_id(N'Kiosk.Person') is null
begin
	create table Kiosk.Person
	(
		PersonID int not null identity(1,1) primary key, 
		Email nvarchar(128) not null, 
		[Name] nvarchar(64) not null, 
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())

		unique(Email) --need to make a unique constraint. 
	); 
end; 