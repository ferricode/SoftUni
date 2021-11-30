
--1.	Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
SELECT FirstName, LastName
	FROM Employees
  WHERE Salary > 35000

--EXEC usp_GetEmployeesSalaryAbove35000 

--2.	Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@inputSalary decimaL(18,4))
AS
SELECT FirstName, LastName
	FROM Employees
  WHERE Salary >= @inputSalary

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3.	Town Names Starting With

CREATE PROC usp_GetTownsStartingWith (@subName NVARCHAR(30))
AS
SELECT [Name] 
  FROM Towns
WHERE [Name] LIKE @subName+'%'

EXEC usp_GetTownsStartingWith 'b'

--4.	Employees from Town

CREATE PROC usp_GetEmployeesFromTown (@town NVARCHAR(50))
AS
SELECT e.FirstName, e.LastName
  FROM Employees AS e
  JOIN Addresses AS a ON a.AddressID=e.AddressID
  JOIN Towns AS t ON t.TownID=a.TownID
  WHERE t.[Name]=@town

EXEC usp_GetEmployeesFromTown Sofia

--5.	Salary Level Function

--1.Variant
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10);
	IF (@salary < 30000)
		SET @result='Low';
	ELSE IF(@salary <=50000)
		SET @result = 'Average';
	ELSE
		SET @result = 'High';
	RETURN @result; 
END

SELECT LOWER(FirstName), dbo.ufn_GetSalaryLevel(Salary),Salary FROM Employees

--2. Variant
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @result VARCHAR(50);
	
SET @result =(CASE
	WHEN @salary < 30000 THEN 'Low'
	WHEN @salary <=50000 THEN 'Average'
	ELSE 'High'
END)

--6.	Employees by Salary Level
CREATE PROC  usp_EmployeesBySalaryLevel(@level VARCHAR(10))
AS
SELECT FirstName,
	   LastName
	FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @level
 
 EXEC usp_EmployeesBySalaryLevel 'High'

--7.	Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
BEGIN 
DECLARE @count INT = 1;

WHILE (@count <= LEN(@word))
BEGIN
	DECLARE @currentLetter CHAR(1)= SUBSTRING(@word, @count,1)
	IF (CHARINDEX(@currentLetter,@setOfLetters ) = 0)
		RETURN 0;
   SET @count+=1;
END
RETURN 1
END

GO
SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')
GO 
--8.	* Delete Employees and Departments
GO
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
	SET ManagerID = NULL
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
	SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments
	SET ManagerID = NULL
WHERE DepartmentID=@departmentId

DELETE FROM Employees
   WHERE DepartmentID = @departmentId

DELETE FROM Departments
	WHERE DepartmentID = @departmentId

SELECT COUNT(*)
	FROM Employees 
WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 2
GO
--9.	Find Full Name
USE Bank
GO
CREATE OR ALTER PROC usp_GetHoldersFullName 
AS
SELECT FirstName+' '+LastName
 FROM AccountHolders

 EXEC usp_GetHoldersFullName

 --10.	People with Balance Higher Than

CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@money DECIMAL(15,2))
AS 
SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
    JOIN Accounts AS a ON ah.Id=a.AccountHolderId
  GROUP BY ah.FirstName, ah.LastName
  	HAVING SUM(Balance) > @money
  ORDER BY FirstName, LastName

EXEC usp_GetHoldersWithBalanceHigherThan 55000


SELECT *
FROM AccountHolders
SELECT * 
FROM Accounts

--11.	Future Value Function
GO
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (
			@sum DECIMAL(15,4),		
			@yearlyInterestRate FLOAT,
			@numberOfYears INT)
RETURNS DECIMAL(15,4)
BEGIN 
	DECLARE @Result DECIMAL(15,4)
	SET @Result = (@sum*POWER((1 + @yearlyInterestRate), @numberOfYears))
	RETURN @Result
END
GO 

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)

---12.	Calculating Interest

GO
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
SELECT a.Id, 
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name], 
	   a.Balance AS [Current Balance], 
	   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
    JOIN Accounts AS a ON a.AccountHolderId=ah.Id
  WHERE a.Id = @accountId


EXEC usp_CalculateFutureValueForAccount 1, 0.1

--13.	*Scalar Function: Cash in User Games Odd Rows
GO
USE Diablo

GO
CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100)) 
RETURNS TABLE 
AS
RETURN (SELECT SUM(k.TotalCash) AS TotalCash
FROM (SELECT Cash AS TotalCash, 
		ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
    FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId=g.Id
	WHERE Name =@gameName) AS k
  WHERE k.RowNumber % 2 = 1
  )

  SELECT * FROM dbo.ufn_CashInUsersGames ('Lisbon')