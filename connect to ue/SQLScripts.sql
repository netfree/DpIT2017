IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Inserare_Utilizator')
DROP PROCEDURE Inserare_Utilizator
GO

create procedure Inserare_Utilizator (@email nvarchar(max), @parola nvarchar (max), @tip_utilizator int)
as 
begin

	insert into Utilizator values(@email, @parola, @tip_utilizator)
    select SCOPE_IDENTITY() as 'Utilizator_ID'
end

go

----------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Verificare_Utilizator')
DROP PROCEDURE  Verificare_Utilizator
GO
create procedure Verificare_Utilizator (@email nvarchar(max), @parola nvarchar (max))
as
begin

	if exists (select Email from Utilizator where Email = @email) 
	begin
	declare @p nvarchar(max) 
	select @p = parola from utilizator where email = @email 
	   if @p = @parola select 'Autentificare reusita'
	   else select 'Parola incorecta'
    end
	else select 'Email incorect sau cont inexistent'


end

go 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Selectare_Canale')
DROP PROCEDURE Selectare_Canale
GO

create procedure Selectare_Canale 
as
begin
	select * from Canal where Activ = 1
end

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Inserare_Preferinte')
DROP PROCEDURE Inserare_Preferinte
GO

create procedure Inserare_Preferinte(@UtilizatorID int, @CanalID int)
as
begin
	insert into Utilizator_Canal values(@UtilizatorID , @CanalID)
end

go

-------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Generare_canale_preferate')
DROP PROCEDURE Generare_canale_preferate
GO

create procedure Generare_canale_preferate(@UtilizatorID int)
as
begin
	select Canal.ID,Nume
	from Utilizator_Canal inner join Canal on Utilizator_Canal.CanalID=Canal.ID
	where @UtilizatorID = UtilizatorID and Canal.Activ = 1
end

go

--------------------------------

