if object_id(N'Kiosk.Category') is null
begin
	create table Kiosk.Category
	(
		CategoryId int not null identity(1,1) primary key, 
		[Name] nvarchar(64) not null

		unique([Name])
	); 
end; 