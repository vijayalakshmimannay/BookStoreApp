use BookStoreDB;

----Create table for book -----
Create Table Book
(
BookId int identity(1,1) not null primary key,
BookName varchar(270) not null,
AuthorName varchar(200) not null,
Rating  varchar(10) not null,
RatingCount int ,
DiscountPrice varchar(10) not null,
ActualPrice varchar(10) not null,
Description varchar(max) not null,
BookImage varchar(250),
BookQuantity int not null
);

select * from Book

update Book SET BookQuantity = '49' where BookId = '1'


--------Adding book--------


Go
CREATE PROCEDURE [AddBook] @BookName VARCHAR(100), @AuthorName VARCHAR (100), @Rating varchar(10),@RatingCount int,@DiscountPrice varchar(10),@ActualPrice varchar(10),@Description varchar(max),@BookImage varchar(250),
@BookQuantity int
AS
BEGIN

insert into Book values(@BookName,@AuthorName,@Rating,@RatingCount,@DiscountPrice,@ActualPrice,@Description,@BookImage,@BookQuantity);

END

-------------- GetBook by Id ----------------

Go
CREATE PROCEDURE [GetBookById] @BookId int
AS
BEGIN
select * from Book where BookId=@BookId
END

---------------- Get All Book ---------------

Go
CREATE PROCEDURE [GetAllBooks] 
AS
BEGIN
select * from Book 
END

----------------- Update Book ----------------

Go
CREATE PROCEDURE [UpdateBook] @BookId int, @BookName VARCHAR(200), @AuthorName VARCHAR (200), @Rating varchar(10),@RatingCount int,@DiscountPrice varchar(10),@ActualPrice varchar(10),@Description varchar(max),@BookImage varchar(250),
@BookQuantity int
AS
BEGIN

update Book set 
BookName=@BookName,
AuthorName=@AuthorName,Rating=@Rating,RatingCount=@RatingCount,DiscountPrice=@DiscountPrice,ActualPrice=@ActualPrice,Description=@Description,BookImage=@BookImage,BookQuantity=@BookQuantity
where BookId=@BookId	
END

----------------- Delete Book ----------------

CREATE PROCEDURE [DeleteBook] @BookId int
AS
BEGIN
DELETE FROM Book Where BookId=@BookId
END