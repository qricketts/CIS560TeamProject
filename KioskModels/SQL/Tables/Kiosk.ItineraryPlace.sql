if object_id(N'Kiosk.ItineraryPlace') is null
begin
	create table Kiosk.ItineraryPlace
	(
		ItineraryPlaceId int not null identity(1,1) primary key, 
		ItineraryId int not null foreign key 
			references Kiosk.Itinerary(ItineraryId), 
		PlaceId int not null foreign key
			references Kiosk.Place(PlaceId), 
		CreatedOn datetimeoffset not null default(sysdatetimeoffset()), 
		UpdatedOn datetimeoffset not null default(sysdatetimeoffset())
	); 
end; 