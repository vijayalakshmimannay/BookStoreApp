USE BookStoreDB

CREATE TABLE Orders(
	OrderId int identity(1,1) primary key,
	OrderQty int not null,
	TotalPrice float not null,
	OrderDate Date not null,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Book(BookId),
	AddressId int not null FOREIGN KEY REFERENCES AddressTable(AddressID)
	)

SELECT * FROM Orders

