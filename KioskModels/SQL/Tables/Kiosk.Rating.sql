if object_id(N'Kiosk.Rating') is null
begin
	create table Kiosk.Rating
	(
		RatingId int not null identity(1,1) primary key, 
		Rate int not null check(Rate between 1 and 5), 
		PersonId int not null foreign key
			references Kiosk.Person(PersonId), 
		PlaceId int not null foreign key
			references Kiosk.Place(PlaceId), 
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())
	); 
end; 
