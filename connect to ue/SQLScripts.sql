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
 
 select *  
 from Utilizator   
 where email = @email and parola = @parola   

end
---------------------
  

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



IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Selectare_Articole')
DROP PROCEDURE Selectare_Articole
GO

create procedure Selectare_Articole 
as
begin
	select * from Articol
end

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Selectare_Articole_cu_canal')
DROP PROCEDURE Selectare_Articole
GO

create procedure Selectare_Articole
as
begin
	select * from Articol
end

go
--------------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Selectare_Articole_cu_canal')
DROP PROCEDURE Selectare_Articole_cu_canal
GO

create procedure Selectare_Articole_cu_canal(@mycanal int)
as
begin
	select *
	from Articol_canal inner join Articol on Articol.Id = Articol_canal.Id_articol  
	where Id_canal = @mycanal
end

go

--------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'giveNumegetID')
DROP PROCEDURE giveNumegetID
GO

create procedure giveNumegetID(@canal_nume nvarchar(max))
as
begin
	select Canal.ID
	from Canal 
	where Canal.Nume = @canal_nume and Canal.Activ = 1;
end

go

---------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'giveTipUtilizatorgetID')
DROP PROCEDURE giveTipUtilizatorgetID
GO

create procedure giveTipUtilizatorgetID (@tip_utilizator_name varchar(max) )
as
begin
	select TipUtilizator.ID from TipUtilizator where TipUtilizator.Nume = @tip_utilizator_name
end

go

--------------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'giveIDgetTipUtilizator')
DROP PROCEDURE giveIDgetTipUtilizator
GO

create procedure giveIDgetTipUtilizator (@tip_utilizator_id int)
as
begin
	select TipUtilizator.Nume from TipUtilizator where TipUtilizator.Id = @tip_utilizator_id
end

go


----------------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'insertArticle')
DROP PROCEDURE insertArticle
GO

create procedure insertArticle (@title nvarchar(max), @content nvarchar(max), @author nvarchar (max))
as 
begin

	insert into Articol values(@title, @content , 1, @author , 1)

	select Articol.Id from Articol where Articol.Titlu = @title and Articol.Continut = @content

end

go

-------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'deleteAllChannelsFromArticle')
DROP PROCEDURE deleteAllChannelsFromArticle
GO

create procedure deleteAllChannelsFromArticle (@articleId int)
as
begin
	delete from Articol_canal where Articol_canal.Id_articol = @articleId
end

go
--------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'giveEmailgetID')
DROP PROCEDURE giveEmailgetID
GO

create procedure giveEmailgetID (@email varchar(max) )
as
begin
	select Utilizator.ID from Utilizator where Utilizator.Email = @email
end

go


---------------------------------


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'addChannelToArticle')
DROP PROCEDURE addChannelToArticle
GO

create procedure addChannelToArticle(@channelId int, @articleId int)
as
begin
	insert into Articol_canal values(@channelId , @articleId)
end

go

------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'deleteAllChannelsFromUser')
DROP PROCEDURE deleteAllChannelsFromUser
GO

create procedure deleteAllChannelsFromUser (@userId int)
as
begin
	delete from Utilizator_Canal where Utilizator_Canal.UtilizatorID = @userId
end

go

------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'channelBelongtoUser')
DROP PROCEDURE channelBelongtoUser
GO

create procedure channelBelongtoUser (@channelId int, @userId int)
as
begin
	select * from Utilizator_Canal where Utilizator_Canal.UtilizatorID = @userId and Utilizator_Canal.CanalID = @channelId
end

go

-------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetHasedPasswdForUser')
DROP PROCEDURE GetHasedPasswdForUser
GO

create procedure GetHasedPasswdForUser(@user nvarchar(max))
as
begin
	select Utilizator.Parola
	from Utilizator
	where Utilizator.Email = @user
end

go

------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllDataForUser')
DROP PROCEDURE GetAllDataForUser
GO

create procedure GetAllDataForUser(@user nvarchar(max))
as
begin
	select *
	from Utilizator
	where Utilizator.Email = @user
end

go
