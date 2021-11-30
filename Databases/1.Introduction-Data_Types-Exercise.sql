

--Problem 2.Create Tables
--In the newly created database Minions add table Minions (Id, Name, Age). 
--Then add new table Towns (Id, Name).
--Set Id columns of both tables to be primary key as constraint

USE Minions
DROP TABLE Minions
CREATE TABLE Minions
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Age INT
)
CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL
)

--Problem 3.	Alter Minions Table

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionsTownId FOREIGN KEY (TownId) REFERENCES Towns(Id)

--Problem 4.	Insert Records in Both Tables
--Towns
	--	Id	Name
	--1	Sofia
	--2	Plovdiv
	--3	Varna
--Minions
	--Id	Name	Age	TownId
	--1	Kevin	22	1
	--2	Bob	15	3
	--3	Steward	NULL	2


INSERT INTO Towns ([Id], [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3,'Varna')

SET IDENTITY_INSERT [dbo].[Minions] ON
GO
INSERT INTO Minions(Id, [Name],Age, TownId) VALUES
(1,	'Kevin',	22,	1),
(2,	'Bob',	15,	3),
(3,	'Steward',	NULL,	2)

--Problem 5.	Truncate Table Minions /изтрива всички данни в таблицата/
TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables/изтриват се една по една/
DROP TABLE Minions
DROP TABLE Towns

--Problem 7.	Create Table People

CREATE TABLE People
(
 Id INT PRIMARY KEY IDENTITY NOT NULL,
 [Name] NVARCHAR(200) NOT NULL,
 Picture IMAGE,
 Height DECIMAL(4,2),
 [Weight] DECIMAL(5,2),
 Gender CHAR(1) NOT NULL,
 Birthdate DATE NOT NULL,
 Biography NVARCHAR(MAX),
 
 CHECK(Gender IN('m','f'))

)
 INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) Values
 ('Pepi Pecov',Null, 1.89,80.90,'m','12-02-1993', Null),
 ('Gogo Pecov',Null, 1.79,70.90,'m', '12-02-1976',  Null),
 ('Lili Gacova',Null, 1.79,70.90,'f', '12-07-1984',  Null),
 ('Ani Rangelova',Null, 1.64,75.90,'f', '12-11-1984',  Null),
 ('Radina Lileva',Null, 1.75,78.00,'f', '05-11-1994',  Null)

--Problem 8.	Create Table Users
--Var 1(samostoiatelno praveno)
CREATE TABLE Users 
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30),
	[Password] VARCHAR(30),
	ProfilePicture Image,
	LastLoginTime DATETIME2,
	IsDeleted BIT,

)
INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime, IsDeleted) VALUES
('Kalinka','kroki45',NULL,'10-04-2021 08:09:14.00', 0),
('Galia','mania78',NULL,'11-04-2020 03:12:34.00', 1),
('Rosen','roshkoko',NULL,'10-07-2019 04:56:11.00', 0),
('Pedro','pardesendro',NULL,'10-04-2021 08:09:14.00', 1),
('Garabed','gonzo21',NULL,'10-03-2018 08:09:14.00', 1)

--VAR 2(praveno v chas s polzvane na BINARY)
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] BINARY(96) NOT NULL,
	[ProfilePicture] VARBINARY (MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
	)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Lili', HASHBYTES('SHA1','123'), NULL, CONVERT(datetime,'22-05-2021',103),0),
('Gogo', HASHBYTES('SHA1','12254253'), NULL, CONVERT(datetime,'12-06-2021',103),0),
('Pepi', HASHBYTES('SHA1','1225423'), NULL, CONVERT(datetime,'01-01-2021', 103),0),
('Ivan', HASHBYTES('SHA1','1543523'), NULL, CONVERT(datetime,'24-02-2021',103),0),
('Kiro', HASHBYTES('SHA1','53453'), NULL, CONVERT(datetime,'14-02-2021',103),0)

--Problem 13.	Movies Database
SET IDENTITY_INSERT [dbo].[Genres] Off 
SET IDENTITY_INSERT [dbo].[Categories] ON 


CREATE Database Movies

CREATE TABLE Directors
(
  Id INT PRIMARY KEY,
  DirectorName VARCHAR (30) NOT NULL,
  Notes VARCHAR(MAX)
)
INSERT INTO Directors(Id,
                      DirectorName
                     )
VALUES
( 1,'Director One'),
( 2,'Director Two'),
( 3,'Director Three'),
(4,'Director Four'),
(5,'Director Five');

CREATE TABLE Genres
(
  Id INT PRIMARY KEY,
  GenreName VARCHAR (30) NOT NULL,
  Notes VARCHAR(MAX)
)
INSERT INTO Genres(Id,GenreName)VALUES
(1,'Genre One'),
(2,'Genre Two'),
(3,'Genre Three'),
(4,'Genre Four'),
(5,'Genre Five')
CREATE TABLE Categories 
(
  Id INT PRIMARY KEY,
  CategoryName VARCHAR (30) NOT NULL,
  Notes VARCHAR(MAX)
)
INSERT INTO Categories(Id,CategoryName)VALUES
(1,'Category One'),
(2,'Category Two'),
(3,'Category Three'),
(4,'Category Four'),
(5,'Category Five')

CREATE TABLE Movies 
(
  Id INT PRIMARY KEY IDENTITY,
  Title VARCHAR (30) NOT NULL,
  DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
  CopyrightYear INT,
  [Length] TIME,
  GenreId INT FOREIGN KEY REFERENCES Genres(Id),
  CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
  Rating DECIMAL(5,2),
  Notes VARCHAR(MAX)
)
INSERT INTO Movies(Title,DirectorId,GenreId,CategoryId) VALUES
('Title1',2,3,4),
('Title2',3,4,5),
('Title3',1,2,3),
('Title4',5,1,3),
('Title5',3,5,2)

--Problem 14. Car Rental Database
CREATE DATABASE CarRental;
GO

USE CarRental;

CREATE TABLE Categories
(
             Id INT PRIMARY KEY IDENTITY,
             CategoryName NVARCHAR(50) NOT NULL,
             DailyRate    DECIMAL(10, 2),
             WeeklyRate   DECIMAL(10, 2),
             MonthlyRate  DECIMAL(10, 2),
             WeekendRate  DECIMAL(10, 2)
			);

ALTER TABLE Categories
ADD CONSTRAINT CK_AtLeastOneRate CHECK((DailyRate IS NOT NULL)
                                       OR (WeeklyRate IS NOT NULL)
                                       OR (MonthlyRate IS NOT NULL)
                                       OR (WeekendRate IS NOT NULL));

INSERT INTO Categories(CategoryName,DailyRate, WeeklyRate,MonthlyRate,WeekendRate)VALUES
('Category 1',10,30,100,40),
('Category 2',20,40,110,50),
('Category 3',30,50,150,60)


CREATE TABLE Cars
(
             Id           INT PRIMARY KEY IDENTITY,
             PlateNumber  VARCHAR(50) NOT NULL,
             Manufacturer VARCHAR(50) NOT NULL,
             Model        VARCHAR(50) NOT NULL,
             CarYear      INT NOT NULL,
             CategoryId   INT NOT NULL
                              FOREIGN KEY REFERENCES Categories(Id),
             Doors        TINYINT NOT NULL,
             Picture      VARBINARY(MAX),
             Condition    NVARCHAR(50),
             Available    BIT DEFAULT 1
);

INSERT INTO Cars( PlateNumber,
                 Manufacturer,
                 Model,
                 CarYear,
                 CategoryId,
                 Doors,
                 Available
                )
VALUES
('CM3245AP','BMW','320','2002',1,2,1),
('CM8932AB','BMW','320','2005',3,2,1),
('CM8932OC','BMW','320','2005',1,3,2)


CREATE TABLE Employees
(
             Id        INT PRIMARY KEY IDENTITY,
             FirstName NVARCHAR(50) NOT NULL,
             LastName  NVARCHAR(50) NOT NULL,
             Title     NVARCHAR(50) NOT NULL,
             Notes     NVARCHAR(MAX)
);

INSERT INTO Employees(FirstName,
                      LastName,
                      Title
                     )
VALUES
('First','One', 'Mechanic'
),
('Second','Two','Team Leader'
),
('Third','Three','Boss');

CREATE TABLE Customers
(
             Id                  INT PRIMARY KEY IDENTITY,
             DriverLicenceNumber VARCHAR(50)
             UNIQUE NOT NULL,
             FullName            NVARCHAR(50) NOT NULL,
             [Address]           NVARCHAR(255),
             City                NVARCHAR(50),
             ZIPCode             NVARCHAR(50),
             Notes               NVARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber,FullName)
VALUES
('1233256','First Name'),
('7821932','Second Name'),
('32920348','Third Name');

CREATE TABLE RentalOrders
(
             Id               INT PRIMARY KEY IDENTITY,
             EmployeeId       INT NOT NULL
                                  FOREIGN KEY REFERENCES Employees(Id),
             CustomerId       INT NOT NULL
                                  FOREIGN KEY REFERENCES Customers(Id),
             CarId            INT NOT NULL
                                  FOREIGN KEY REFERENCES Cars(Id),
             TankLevel        NUMERIC(5, 2),
             KilometrageStart INT,
             KilometrageEnd   INT,
             TotalKilometrage INT,
             StartDate        DATE NOT NULL,
             EndDate          DATE NOT NULL,
             TotalDays        INT NOT NULL, 
             RateApplied      DECIMAL(10, 2),
             TaxRate          DECIMAL(10, 2),
             OrderStatus      NVARCHAR(50),
             NOTES            NVARCHAR(MAX)
);

ALTER TABLE RentalOrders
ADD CONSTRAINT CK_TotalDays CHECK(DATEDIFF(DAY, StartDate, EndDate) = TotalDays);

INSERT INTO RentalOrders( EmployeeId,
                         CustomerId,
                         CarId,
                         StartDate,
                         EndDate,
                         TotalDays
                        )
VALUES
(3,3,3,'01-01-2010','01-02-2010',1),
( 1, 1,1,'01-01-2010','01-03-2010',2),
(2,2,2,'01-01-2010','01-04-2010',3);

--Problem 15.	Hotel Database

CREATE DATABASE Hotel;
GO

USE Hotel;

CREATE TABLE Employees
(
             Id        INT PRIMARY KEY IDENTITY,
             FirstName NVARCHAR(50) NOT NULL,
             LastName  NVARCHAR(50) NOT NULL,
             Title     NVARCHAR(255) NOT NULL,
             Notes     NVARCHAR(MAX)
);

INSERT INTO Employees(FirstName,LastName,Title)
VALUES
('First','LastName','Manager'),
('Second', 'Last','Mechanic'),
('Third','LastN','Waiter');

CREATE TABLE Customers
(
             AccountNumber   INT
             PRIMARY KEY NOT NULL,
             FirstName       NVARCHAR(50) NOT NULL,
             LastName        NVARCHAR(50) NOT NULL,
             PhoneNumber     VARCHAR(50),
             EmergencyName   NVARCHAR(50) NOT NULL,
             EmergencyNumber INT NOT NULL,
             Notes           NVARCHAR(50)
);

INSERT INTO Customers(AccountNumber,
                      FirstName,
                      LastName,
                      EmergencyName,
                      EmergencyNumber
                     )
VALUES
(1,'First','Customer', 'Em1',11111),
(22,'Second','Customer', 'Em2',22222),
(333,'Third','Customer', 'Em3',33333)


CREATE TABLE RoomStatus
(
             RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
             Notes      NVARCHAR(MAX)
);

INSERT INTO RoomStatus(RoomStatus)
VALUES
('Free'),
('In use'),
('Reserved');

CREATE TABLE RoomTypes
(
             RoomType NVARCHAR(50)
             PRIMARY KEY NOT NULL,
             Notes    NVARCHAR(MAX)
);

INSERT INTO RoomTypes(RoomType)
VALUES
(
       'Luxory'
),
(
       'Casual'
),
(
       'Misery'
);

CREATE TABLE BedTypes
(
             BedType NVARCHAR(50)
             PRIMARY KEY NOT NULL,
             Notes   NVARCHAR(MAX)
);

INSERT INTO BedTypes(BedType)
VALUES
(
       'Single'
),
(
       'Double'
),
(
       'King'
);

CREATE TABLE Rooms
(
             RoomNumber INT PRIMARY KEY NOT NULL,
             RoomType   NVARCHAR(50) NOT NULL,
             BedType    NVARCHAR(50) NOT NULL,
             Rate       DECIMAL(10, 2) NOT NULL,
             RoomStatus NVARCHAR(50) NOT NULL,
             Notes      NVARCHAR(MAX)
);

INSERT INTO Rooms(RoomNumber,
                  RoomType,
                  BedType,
                  Rate,
                  RoomStatus
                 )
VALUES
(101,'Luxory','King',68.33,'Reserved'),
(102, 'Casual','Double',98.43,'In use'),
(103,'Misery','Single',57.30,'Free')

CREATE TABLE Payments
(
             Id                INT PRIMARY KEY IDENTITY,
             EmployeeId        INT NOT NULL,
             PaymentDate       DATE NOT NULL,
             AccountNumber     INT NOT NULL,
             FirstDateOccupied DATE NOT NULL,
             LastDateOccupied  DATE NOT NULL,
             TotalDays         INT NOT NULL,
             AmountCharged     DECIMAL(10, 2) NOT NULL,
             TaxRate           DECIMAL(10, 2) NOT NULL,
             TaxAmount         DECIMAL(10, 2) NOT NULL,
             PaymentTotal      DECIMAL(10, 2) NOT NULL,
             Notes             NVARCHAR(MAX)
);

ALTER TABLE Payments
ADD CONSTRAINT CK_TotalDays CHECK(DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied) = TotalDays);

ALTER TABLE Payments
ADD CONSTRAINT CK_TaxAmount CHECK(TaxAmount = TotalDays * TaxRate);

INSERT INTO Payments(EmployeeId,
                     PaymentDate,
                     AccountNumber,
                     FirstDateOccupied,
                     LastDateOccupied,
                     TotalDays,
                     AmountCharged,
                     TaxRate,
                     TaxAmount,
                     PaymentTotal
                    )
VALUES
(1,'10-05-2015',1,'10-05-2015','10-10-2015', 5,75,50,250,75),
(2,'10-11-2015',1, '12-15-2015','12-25-2015',10,100,50,500,100),
(3,'12-23-2015',2, '12-23-2015','12-24-2015',1,75,75,75,75)


CREATE TABLE Occupancies
(
             Id            INT
             PRIMARY KEY NOT NULL,
             EmployeeId    INT NOT NULL,
             DateOccupied  DATE NOT NULL,
             AccountNumber INT NOT NULL,
             RoomNumber    INT NOT NULL,
             RateApplied   DECIMAL(10, 2),
             PhoneCharge   VARCHAR(50) NOT NULL,
             Notes         NVARCHAR(MAX)
);

INSERT INTO Occupancies(Id,
                        EmployeeId,
                        DateOccupied,
                        AccountNumber,
                        RoomNumber,
                        PhoneCharge
                       )
VALUES
(1,2,'08-24-2012', 3,1,'088 88 888 888'),
(2, 3,'06-15-2015',2,3,'088 88 555 555'),
( 3,1,'05-12-1016',1,2,'088 88 555 333');


--Problem 16.	Create SoftUni Database
CREATE DATABASE	SoftUni

USE SoftUni

CREATE TABLE Towns
(
		Id INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(20) NOT NULL
)
CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(30) NOT NULL,
	TownId INT CONSTRAINT FK_Addresses_Towns FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments
(
		Id INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(20) NOT NULL
)
CREATE TABLE Employees
(
		Id INT PRIMARY KEY IDENTITY,
		FirstName NVARCHAR(30) NOT NULL,
		MiddleName NVARCHAR(30) NOT NULL,
		LastName NVARCHAR(30) NOT NULL,
		JobTitle NVARCHAR(30) NOT NULL,
		DepartmentId INT CONSTRAINT FK_Employees_Departments FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
		HireDate DATE NOT NULL,
		Salary DECIMAL(15,2) NOT NULL,
		AddressId INT CONSTRAINT FK_Employees_Addresses FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)
--Problem 18.	Basic Insert
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

--Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO Departments ([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

SELECT * FROM  Departments

--Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
--Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
--Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
--Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
--Peter Pan Pan	Intern	Marketing	28/08/2016	599.88

ALTER TABLE Employees
ALTER COLUMN AddressId INT

INSERT Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate,Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov','.NET Developer',4, CONVERT(datetime,'01/02/2013',103), 3500),
('Petar', 'Petrov', 'Petrov','.Senior Engineer',1, CONVERT(datetime,'02/03/2004', 103), 4000),
('Maria', 'Petrova', 'Ivanova','Intern',5, CONVERT(datetime,'28/08/2016',103), 525.25),
('Georgi', 'Terziev', 'Ivanov','CEO	Sales',2, CONVERT(datetime,'09/12/2007',103), 3000.00),
('Peter', 'Pan', 'Pan','Marketing',3, CONVERT(datetime,'09/12/2007',103), 599.88)

--Problem 19.	Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20.	Basic Select All Fields and Order Them

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21.	Basic Select Some Fields

SELECT Name FROM Towns
ORDER BY [Name]

SELECT Name FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--Problem 22.	Increase Employees Salary
UPDATE Employees
SET Salary *=1.1

SELECT Salary FROM Employees

--23 Exercise
USE Hotel

--ALTER TABLE Payments
--DROP CONSTRAINT [CK_TaxAmount];

UPDATE Payments SET TaxRate = TaxRate - (TaxRate*0.03)

SELECT TaxRate FROM Payments

--Problem 24.	Delete All Records
USE Hotel

TRUNCATE TABLE Occupancies;
DELETE  Occupancies;
--TRUNCATE TABLE Occupancies

--TRUNCATE deletes faster than DELETE
