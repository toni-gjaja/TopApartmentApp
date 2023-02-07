CREATE OR ALTER PROCEDURE SelectApartments
AS
select AP.Id as ApartmentId, AO.Id as OwnerId, AO.Name as OwnerName,
AST.Id as StatusId, AST.Name as StatusName, AST.NameEng as StatusNameEng, C.Id as CityId, C.Name as CityName, AP.Address as ApartmentAdress,
AP.Name as ApartmentName, AP.NameEng as ApartmentNameEng,
AP.Price, AP.MaxAdults, AP.MaxChildren, AP.TotalRooms, AP.BeachDistance
from Apartment as AP
inner join ApartmentOwner as AO on AP.OwnerId = AO.Id
inner join ApartmentStatus as AST on AP.StatusId = AST.Id
inner join City as C on AP.CityId = C.Id
where AP.DeletedAt IS NULL

go

CREATE OR ALTER PROCEDURE GetApartmentsForAutoComplete
@Name nvarchar(20)
as
select Id, Name
from Apartment
where Name like @Name + '%'

go

CREATE OR ALTER PROCEDURE  SelectApartment
@Id int
AS
select AP.Id as ApartmentId, AO.Id as OwnerId, AO.Name as OwnerName,
AST.Id as StatusId, AST.Name as StatusName, AST.NameEng as StatusNameEng, C.Id as CityId, C.Name as CityName, AP.Address as ApartmentAdress,
AP.Name as ApartmentName, AP.NameEng as ApartmentNameEng,
AP.Price, AP.MaxAdults, AP.MaxChildren, AP.TotalRooms, AP.BeachDistance
from Apartment as AP
inner join ApartmentOwner as AO on AP.OwnerId = AO.Id
inner join ApartmentStatus as AST on AP.StatusId = AST.Id
inner join City as C on AP.CityId = C.Id
where Ap.Id = @Id

go

CREATE OR ALTER PROCEDURE  UpdateApartment
@Id int, @StatusId int, @Address nvarchar(20), @Name nvarchar(20), @NameEng nvarchar(20),
@Price nvarchar(20), @MaxAdults nvarchar(20), @MaxChildren nvarchar(20), @TotalRooms nvarchar(20), @BeachDistance nvarchar(20)
as
update Apartment
set StatusId = @StatusId, Address = @Address, Name = @Name, NameEng = @NameEng, Price = CONVERT(money, @Price),
MaxAdults = CAST(@MaxAdults as int), MaxChildren = CAST(@MaxChildren as int), TotalRooms = CAST(@TotalRooms as int), BeachDistance = CAST(@BeachDistance as int)
where Id = @Id

go

CREATE OR ALTER PROCEDURE  DeleteApartment
@Id int
as
update Apartment
set DeletedAt = GETDATE()
where Id = @Id
delete from TaggedApartment where ApartmentId = @Id

go

CREATE OR ALTER PROCEDURE GetApIdByName
@Name nvarchar(50)
as
select Id from Apartment where Name = @Name

go

CREATE OR ALTER PROCEDURE AddTagToApartment
@apId int,
@tagId int
as
if not exists(select * from TaggedApartment where TagId = @tagId and ApartmentId = @apId)
	begin
		insert into TaggedApartment(Guid, ApartmentId, TagId)
		values (NEWID(), @apId, @tagId)
	end

go

CREATE OR ALTER PROCEDURE  GetApartmentOwners
as
select Id, Name from ApartmentOwner

go

CREATE OR ALTER PROCEDURE  GetAllCities
as
select Id, Name from City

go

CREATE OR ALTER PROCEDURE  CreateNewOwner
@Name nvarchar(50)
as
insert into ApartmentOwner ([Guid], [CreatedAt], [Name])
values (NEWID(), GETDATE(), @Name)

go

CREATE OR ALTER PROCEDURE  CreateNewApartment
@OwnerId int, @StatusId int, @CityId int, @Address nvarchar(20), @Name nvarchar(20), @NameEng nvarchar(20),
@Price nvarchar(20), @MaxAdults nvarchar(20), @MaxChildren nvarchar(20), @TotalRooms nvarchar(20), @BeachDistance nvarchar(20)
as
INSERT INTO Apartment ([Guid], [CreatedAt], [DeletedAt], [OwnerId], [TypeId], [StatusId], [CityId],
[Address], [Name], [NameEng], [Price], [MaxAdults], [MaxChildren], [TotalRooms], [BeachDistance])
values(NEWID(),GETDATE(), NULL, @OwnerId, 999, @StatusId, @CityId, @Address, @Name, @NameEng, CONVERT(money, @Price),
CAST(@MaxAdults as int), CAST(@MaxChildren as int), CAST(@TotalRooms as int), CAST(@BeachDistance as int))

go

CREATE OR ALTER PROCEDURE  GetOwnerId
@Name nvarchar(50)
as
select Id from ApartmentOwner
where Name = @Name

go

CREATE OR ALTER PROCEDURE  GetCityId
@Name nvarchar(50)
as
select Id from City
where Name = @Name

go

CREATE OR ALTER PROCEDURE  SelectUsers
as
select Id, UserName, PhoneNumber, PhoneNumberConfirmed,
Address, Email, EmailConfirmed 
from AspNetUsers
where DeletedAt is null

go

CREATE OR ALTER PROCEDURE  GetReservations
as
select RES.Id, AP.Id as ApId, AP.Name as ApName, RES.Details, USR.Id as UsrId, USR.UserName
from ApartmentReservation as RES
inner join Apartment as AP on RES.ApartmentId = AP.Id
inner join AspNetUsers as USR on RES.UserId = USR.Id

go


CREATE OR ALTER PROCEDURE  GetUnRegUserReservations
as
select ApRes.Id, ApRes.ApartmentId, AP.Name, ApRes.Details,
ApRes.UserName, ApRes.UserEmail, ApRes.UserPhone, ApRes.UserAddress
from ApartmentReservation as ApRes
inner join Apartment as AP on ApRes.ApartmentId = AP.Id
where UserId is null

go

CREATE OR ALTER PROCEDURE  GetReservationDetails
@apartmentId int
as
select ApartmentId, UserId
from ApartmentReservation
where Id = @apartmentId and UserId is not null

go

CREATE OR ALTER PROCEDURE  GetUser
@Id int
as
select Id, UserName, PhoneNumber, PhoneNumberConfirmed, Address, Email, EmailConfirmed
from AspNetUsers
where Id = @Id

go

CREATE OR ALTER PROCEDURE  DeleteReservation
@Id int
as
delete from ApartmentReservation where Id = @Id

go

CREATE OR ALTER PROCEDURE  SelectUnRegUserReservation
@Id int
as
select ApRes.Id, ApRes.ApartmentId,AP.Name, ApRes.Details,
ApRes.UserName, ApRes.UserEmail, ApRes.UserPhone, ApRes.UserAddress
from ApartmentReservation ApRes
inner join Apartment as AP on ApRes.ApartmentId = AP.Id
where ApRes.Id = @Id

go

CREATE OR ALTER PROCEDURE SelectUnusedTags
as
select TG.Id, TG.Name, TT.Name as TypeName from Tag AS TG
left join TaggedApartment as TA on TA.TagId = TG.Id
inner join TagType as TT on TG.TypeId = TT.Id
where TA.TagId is null

go

CREATE OR ALTER PROCEDURE  SelectAssignedTags
as
select TG.Id, TG.Name as TagName, TT.Name as TypeName, AP.Name  as ApName
from TaggedApartment as TA
inner join Apartment as AP on TA.ApartmentId = AP.Id
inner join Tag as TG on TA.TagId = TG.Id
inner join TagType as TT on TG.TypeId = TT.Id
order by AP.Name

go

CREATE OR ALTER PROCEDURE  DeleteTag
@Id int
as
delete from Tag where Id = @Id

go

CREATE OR ALTER PROCEDURE GetTagTypes
as
select Id,Name from TagType

go

CREATE OR ALTER PROCEDURE GetTagTypeId
@Name nvarchar(20)
as
select Id from TagType where Name = @Name

go

CREATE OR ALTER PROCEDURE InsertTag
@TypeId int,
@Name nvarchar(50),
@NameEng nvarchar(50)
as
insert into Tag(Guid, CreatedAt, TypeId, Name, NameEng)
values(NEWID(),GETDATE(),@TypeId,@Name,@NameEng)

go

CREATE OR ALTER PROCEDURE GetTagNames
as
select Name from Tag

go

CREATE OR ALTER PROCEDURE GetTagIdByName
@Name nvarchar(50)
as
select Id from Tag where Name = @Name

go


--mvc dodatne procedure


CREATE OR ALTER PROCEDURE  GetAppUsers
as
select Id, Email, PasswordHash, PhoneNumber, UserName, Address
from AspNetUsers

go

CREATE OR ALTER PROCEDURE  CreateAppUser
	@Email nvarchar(50),
	@PasswordHash nvarchar(max),
	@PhoneNumber nvarchar(50),
	@UserName nvarchar(50),
	@Address nvarchar(50),
	@Id int output
as
begin
	insert into AspNetUsers([Guid], [CreatedAt], [Email], [EmailConfirmed], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [LockoutEnabled], [AccessFailedCount], [UserName], [Address])
	values(NEWID(),GETDATE(),@Email,1,@PasswordHash,@PhoneNumber,1,0,0,@UserName,@Address)
	set @Id = SCOPE_IDENTITY()
end

go

CREATE OR ALTER PROCEDURE  GetAppUser
	@Id int
as
select Id,Email,PasswordHash,PhoneNumber,UserName,Address
from AspNetUsers
where Id = @Id

go

CREATE OR ALTER PROCEDURE GetApartmentStars
	@Id int
as
select Stars
from ApartmentReview
where ApartmentId = @Id

go

CREATE OR ALTER PROCEDURE GetApartmentReviews
	@Id int
as
select ApartmentId,UserId,Details,Stars
from ApartmentReview
where ApartmentId = @Id

go

CREATE OR ALTER PROCEDURE GetTagsForApartment
		@Id int
as
select T.Id, T.Name, TT.Name as Type, A.Name as ApartmentName
from TaggedApartment as TA
inner join Apartment as A on TA.ApartmentId = A.Id
inner join Tag as T on TA.TagId = T.Id
inner join TagType as TT on T.TypeId = TT.Id
where TA.ApartmentId = @Id

go

CREATE OR ALTER PROCEDURE GetUserReviews
	@Id int
as
select ApartmentId,UserId,Details,Stars
from ApartmentReview
where UserID = @Id

go

CREATE OR ALTER PROCEDURE GetUserReservations
	@Id int
as
select AR.Id, AR.ApartmentId, A.Name as ApartmentName, AR.Details, AR.UserId, U.UserName
from ApartmentReservation as AR
inner join Apartment as A on AR.ApartmentId = A.Id
inner join AspNetUsers as U on AR.ApartmentId = U.Id
where AR.UserId = @Id

go

CREATE OR ALTER PROCEDURE LeaveReview
	@ApartmentId int,
	@UserId int,
	@Details nvarchar(max),
	@Stars int
as
insert into ApartmentReview([Guid], [CreatedAt], [ApartmentId], [UserId], [Details], [Stars])
values
(NEWID(),GETDATE(),@ApartmentId,@UserId,@Details,@Stars)

go







