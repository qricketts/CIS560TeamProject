if object_id(N'Kiosk.ItineraryPlace') is null
begin
	create table Kiosk.ItineraryPlace
	(
		ItineraryPlaceID int not null identity(1,1) primary key, 
		ItineraryID int not null foreign key 
			references Kiosk.Itinerary(ItineraryID), 
		PlaceID int not null foreign key
			references Kiosk.Place(PlaceID), 
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())
	); 
end; 