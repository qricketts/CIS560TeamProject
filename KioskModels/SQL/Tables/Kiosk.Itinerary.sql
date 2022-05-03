if object_id(N'Kiosk.Itinerary') is null
begin
	create table Kiosk.Itinerary
	(
		ItineraryId int not null identity(1,1) primary key, 
		PersonId int not null foreign key
			references Kiosk.Person(PersonId), 
		CreatedOn datetimeoffset(7) default(sysdatetimeoffset()),
		UpdatedOn datetimeoffset(7) default(sysdatetimeoffset())
	); 
end; 