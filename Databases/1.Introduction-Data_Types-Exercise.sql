

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


