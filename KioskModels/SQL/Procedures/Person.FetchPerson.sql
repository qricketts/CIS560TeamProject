create or alter procedure Person.FetchPerson
	@PersonId int
as

select P.PersonId, P.[Name], P.Email, P.[Password], P.
values(@Name, @Email, @Password); 

set @PersonId = scope_identity(); 
go