if object_id(N'Kiosk.Itinerary') is null
begin
	create table Kiosk.Itinerary
	(
		ItineraryID int not null identity(1,1) primary key, 
		PersonID int not null foreign key
			references Kiosk.Person(PersonID), 
	); 
end; 