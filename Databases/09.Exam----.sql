CREATE DATABASE Service
USE Service

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME2,
	Age INT NOT NULL
	CHECK(Age BETWEEN 14 AND 110),
	Email  NVARCHAR(50) NOT NULL,
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME2,
	Age INT
	CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT NOT NULL
			FOREIGN KEY REFERENCES Departments(Id)

)

CREATE TABLE Categories
(

	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL
			FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE [Status]
(

	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL
			FOREIGN KEY REFERENCES Categories(Id),
	StatusId INT NOT NULL
			FOREIGN KEY REFERENCES [Status](Id),
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT NOT NULL
			FOREIGN KEY REFERENCES Users(Id),
	EmployeeId INT
		FOREIGN KEY REFERENCES Employees(Id)
)

--Section 2. DML (10 pts)
INSERT INTO Employees(FirstName,	LastName,	Birthdate,	DepartmentId) VALUES
('Marlo',	'O''Malley',	'1958-9-21',	1),
('Niki',	'Stanaghan',	'1969-11-26',	4),
('Ayrton',	'Senna',	'1960-03-21',	9),
('Ronnie',	'Peterson',	'1944-02-14',	9),
('Giovanna',	'Amati',	'1959-07-20',	5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate,	CloseDate, [Description], UserId, EmployeeId)
VALUES
(1,	1,	'2017-04-13',NULL,'Stuck Road on Str.133',	6,	2 ),
(6,	3,	'2015-09-05',	'2015-12-06',	'Charity trail running',	3,	5),
(14, 2,	'2015-09-07', NULL,'Falling bricks on Str.58',	5,	2),
(4,	3,	'2017-07-03','2017-07-06',	'Cut off streetlight on Str.11', 1,	1)

--3.	Update

SELECT *
	FROM Reports

UPDATE Reports SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4.	Delete
SELECT *
FROM Reports

DELETE Reports WHERE StatusId=4

--5.	Unassigned Reports
 SELECT FORMAT (OpenDate, 'dd-MM-yyyy') FROM Reports

SELECT [Description],
	   FORMAT (OpenDate, 'dd-MM-yyyy') 
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

--6.	Reports & Categories
SELECT r.[Description], c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId=c.Id
ORDER BY r.[Description], c.[Name]

--7.	Most Reported Category
SELECT TOP(5) c.[Name] AS CategoryName,
		COUNT(c.[Name]) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId=c.Id
GROUP BY  c.[Name]
ORDER BY COUNT(c.[Name]) DESC, c.[Name]

SELECT *
FROM Reports

--8.	Birthday Report
SELECT u.Username,
		c.[Name] AS CategoryName
FROM Reports AS r
JOIN Users AS u ON r.UserId=u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(DAY, r.OpenDate ) = DATEPART(DAY, u.Birthdate)
	AND DATEPART(MONTH,  r.OpenDate ) = DATEPART(MONTH, u.Birthdate)
ORDER BY u.Username, c.[Name]

SELECT * FROM Users

--9.	Users per Employee 

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, COUNT(u.Id) AS UsersCount 
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY e.Id, e.FirstName, e.LastName
	ORDER BY UsersCount DESC, FullName