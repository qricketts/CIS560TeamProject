﻿create PROCEDURE Kiosk.DeletePlace
   @PlaceId INT 
AS

delete Kiosk.Place
where PlaceId = @PlaceId; 

GO