if not exists 
(
	select *
	from sys.schemas s 
	where s.[name] = N'Kiosk'
)
begin
	exec(N'create schema [Kiosk] authorization [dbo]');
end;