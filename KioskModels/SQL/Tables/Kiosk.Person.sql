if object_id(N'Kiosk.Person') is null
begin
	create table Kiosk.Person
	(
		PersonId int not null identity(1,1) primary key, 
		[Name] nvarchar(32) not null,
		Email nvarchar(64) not null, 
		[Password] nvar(32) not null, 
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())

		unique(Email) --need to make a unique constraint. 
	); 
end; 