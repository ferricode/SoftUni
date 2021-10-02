--Problem 1.	One-To-One Relationship
SET IDENTITY_INSERT dbo.Passports ON

--DROP TABLE Passports
--DROP TABLE Persons

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber CHAR(8)
)
CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30),
	Salary DECIMAL(15,2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00,	102),
('Tom', 56100.00,	103),
('Yana', 60200.00,	101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	EstablishedOn DATETIME
)
CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW',	'07/03/1916'),
('Tesla',	'01/01/2003'),
('Lada',	'01/05/1966')

INSERT INTO Models VALUES
('X1',	1),
('i6',	1),
('Model S',	2),
('Model X',	2),
('Model 3',	2),
('Nova',	3)

--SELECT * FROM Models
--SELECT * FROM Manufacturers

--Problem 3.	Many-To-Many Relationship

CREATE TABLE Students
(
	 StudentID INT PRIMARY KEY IDENTITY
	,Name VARCHAR(30)
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1)
	,Name VARCHAR(30)
)

CREATE TABLE StudentsExams
(
	--variant 1
	-- StudentID INT 
	--,ExamID INT

	--  CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID)
	-- ,CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
	-- ,CONSTRAINT FK_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

	--variant 2
	 StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	,ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)
	 
	 CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID)

)

INSERT INTO Students VALUES
 ('Mila')                                     
,('Toni')
,('Ron ')

INSERT INTO Exams VALUES
('SpringMVC')
,('Neo4j')
,('Oracle 11g')

INSERT INTO StudentsExamS VALUES
 (1,101)
,(1,102)
,(2,101)
,(3,103)
,(2,102)
,(2,103)

--SELECT * FROM StudentsExamS

--Problem 4.	Self-Referencing 
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY (101,1)
	,[Name] VARCHAR(50)
	,ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)
INSERT INTO Teachers VALUES
 ('John',NULL)
,('Maya',106)
,('Silvia',106)
,('Ted',105)
,('Mark',101)
,('Greta',101)



--SELECT * FROM Teachers

--Problem 5.	Online Store Database

--USE  RelationsExerxise

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,Birthday DATE
	,CityID INT FOREIGN KEY REFERENCES Cities(CityID) 
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY
	,CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) 
)
CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID)
	,ItemID INT	FOREIGN KEY REFERENCES Items(ItemID)

	CONSTRAINT PK_Orders_Items PRIMARY KEY( OrderID, ItemID) 
)

--Problem 6.	University Database

CREATE DATABASE University
USE University

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY
	,SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY
	,StudentNumber INT UNIQUE NOT NULL
	,StudentName VARCHAR(50)
	,MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)
CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY
	,PaymentDate DATE
	,PaymentAmount MONEY
	,StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)
CREATE TABLE	Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	,SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)

	CONSTRAINT PK_Student_Subject PRIMARY KEY (StudentID, SubjectID)
)

--Problem 9.	*Peaks in Rila
USE  Geography

SELECT m.MountainRange, p.PeakName, p.Elevation 
    FROM Mountains AS m
    JOIN Peaks As p ON p.MountainId = m.Id
   WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC



