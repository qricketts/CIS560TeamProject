if object_id(N'Kiosk.Rating') is null
begin
	create table Kiosk.Rating
	(
		RatingID int not null identity(1,1) primary key, 
		Rating int not null check(Rating between 1 and 5), 
		PersonID int not null foreign key
			references Kiosk.Person(PersonID), 
		PlaceID int not null foreign key
			references Kiosk.Place(PlaceID), 
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())
	); 
end; 
