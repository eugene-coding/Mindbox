/*
В базе данных MS SQL Server есть продукты и категории. 
Одному продукту может соответствовать много категорий, 
в одной категории может быть много продуктов. 
Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
Если у продукта нет категорий, то его имя все равно должно выводиться.
*/

CREATE TABLE Products (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(255) NOT NULL
);

SET IDENTITY_INSERT Products ON;

INSERT INTO Products (Id, Title)
VALUES
	(1, 'ROCKDALE AURORA D1 C BK'),
	(2, 'FENDER SQUIER SA-150'),
	(3, 'IBANEZ TCY10E-BK'),
	(4, 'VESTON F-38/BK'),
	(5, 'FENDER CD-60 NATURAL');

SET IDENTITY_INSERT Products OFF;

CREATE TABLE Categories (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(255) NOT NULL
);

SET IDENTITY_INSERT Categories ON;

INSERT INTO Categories (Id, Title)
VALUES
	(1, 'Acoustic guitars'),
	(2, 'Semiacoustic guitars'),
	(3, 'Electric guitars');

SET IDENTITY_INSERT Categories OFF;

CREATE TABLE CategoryProducts (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CategoryId INT,
	ProductId INT,
	CONSTRAINT FK_CategoryProducts_Categories_CategoriesId FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE CASCADE,
	CONSTRAINT FK_CategoryProducts_Products_ProductsId FOREIGN KEY (ProductId) REFERENCES Products (Id) ON DELETE CASCADE
);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
	(1, 1),
	(1, 3),
	(2, 4),
	(2, 1),
	(3, 5);

SELECT c.Title, p.Title FROM Products p
LEFT JOIN CategoryProducts cp
	ON p.Id = cp.ProductId
LEFT JOIN Categories c
	ON c.Id = cp.CategoryId;
