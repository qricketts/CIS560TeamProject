create or alter procedure Person.CreatePerson
	@Name nvarchar(64),
	@Email nvarchar(64),
	@Password nvarchar(32), 
	@CreatedOn datetimeoffset,
	@UpdatedOn datetimeoffset,
	@PersonId int output
as

insert Person.Person([Name], Email, [Password], CreatedOn, UpdatedOn)
values(@Name, @Email, @Password, @CreatedOn, @UpdatedOn); 

set @PersonId = scope_identity(); 
go