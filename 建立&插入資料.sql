--CREATE DATABASE TestMVCCC;

--CREATE TABLE "Orders" (
--	orderId INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
--	categoryId varchar(50),
--	"name" varchar(50),
--	price INT,
--	customer varchar(50),
--	quantity INT NOT NULL
--);

--INSERT INTO dbo.Orders (categoryId, "name", price, customer, quantity)
--VALUES ('Fruit', 'Apple', 25, '小名', 3),
--		('Fruit', 'Banana', 50, '小華', 5),
--		('Fruit', 'Pineapple', 30, '小英', 4),
--		('Fruit', 'Mango', 60, '小李', 6),
--		('Fruit', 'Guava', 30, '小張', 2);


--CREATE TABLE "Categories" (
--	"categoryId" "int" IDENTITY (1, 1) NOT NULL PRIMARY KEY,
--	"categoryName" nvarchar (15) NOT NULL ,
--	"description" "ntext" NULL
--);

--INSERT "Categories"("categoryName","description") 
--VALUES('Beverages','Soft drinks, coffees, teas, beers, and ales')
--INSERT "Categories"("categoryName","description") 
--VALUES('Condiments','Sweet and savory sauces, relishes, spreads, and seasonings')
--INSERT "Categories"("categoryName","description") 
--VALUES('Confections','Desserts, candies, and sweet breads')
--INSERT "Categories"("categoryName","description") 
--VALUES('Dairy Products','Cheeses')
--INSERT "Categories"("categoryName","description") 
--VALUES('Grains/Cereals','Breads, crackers, pasta, and cereal')
--INSERT "Categories"("categoryName","description") 
--VALUES('Meat/Poultry','Prepared meats')
--INSERT "Categories"("categoryName","description") 
--VALUES('Produce','Dried fruit and bean curd')
--INSERT "Categories"("categoryName","description") 
--VALUES('Seafood','Seaweed and fish');
