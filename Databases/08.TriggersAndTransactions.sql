USE Bank
--14.Create Table Logs

SELECT * FROM Accounts

CREATE TABLE Logs
(
  LogId INT PRIMARY KEY IDENTITY,
  AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
  OldSum DECIMAL(15,2),
  NewSum DECIMAL(15,2)
)
GO 

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
DECLARE @accountId INT = (SELECT Id FROM inserted)


INSERT INTO Logs(AccountId,NewSum, OldSum) VALUES
(@accountId,@newSum,@oldSum)


UPDATE Accounts
SET Balance +=10
WHERE Id =1

SELECT * FROM Logs

--15.Create Table Emails

CREATE TABLE NotificationEmails
(
 Id INT PRIMARY KEY IDENTITY,
 Recipient  INT FOREIGN KEY REFERENCES Accounts(Id),
 [Subject] VARCHAR(50),
 Body VARCHAR(MAX)
)
Go

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
DECLARE @oldSum DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM inserted)
DECLARE @newSum DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM inserted)

INSERT INTO NotificationEmails(Recipient,[Subject], Body) VALUES
(@accountId, 
'Balance change for account: ' + CAST(@accountId AS VARCHAR(20)),
'On ' +CONVERT(VARCHAR(30),GETDATE(),103) +' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20))
)

SELECT * FROM NotificationEmails 

UPDATE Accounts
SET Balance +=100
WHERE Id=1


--On Sep 12 2016 2:09PM your balance was changed from 113.12 to 103.12.

--16.	Deposit Money
GO
CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15,4)) 
AS 
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id=@accountId)

IF (@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Inavlid account id!',16,1)
	RETURN
END

IF(@moneyAmount <0)
BEGIN 
ROLLBACK
	RAISERROR('Negative amount!',16,1)
	RETURN
END

UPDATE Accounts
SET Balance+=@moneyAmount
WHERE Id=@accountId
COMMIT

EXEC usp_DepositMoney 1, 247.78
SELECT * FROM Accounts WHERE Id=1

--17.	Withdraw Money
GO
CREATE PROC usp_WithdrawMoney(@accountId INT, @moneyAmount DECIMAL(15,4)) 
AS 
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id=@accountId)
DECLARE @accountBalance DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id=@accountId)

IF (@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Inavlid account id!',16,1)
	RETURN
END

IF(@moneyAmount <0)
BEGIN 
ROLLBACK
	RAISERROR('Negative amount!',16,1)
	RETURN
END

IF(@accountBalance - @moneyAmount < 0)
BEGIN 
ROLLBACK
	RAISERROR('Insufficient funds',16,1)
	RETURN
END
UPDATE Accounts
SET Balance-=@moneyAmount
WHERE Id=@accountId
COMMIT

SELECT * FROM Accounts WHERE Id = 1
EXEC usp_WithdrawMoney 1,600

--18.	Money Transfer
GO
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15,4)) 
AS 
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @receiverId, @amount
COMMIT

SELECT * FROM Accounts WHERE Id=1 OR Id = 2
EXEC usp_TransferMoney 2, 1, 3000

--21.	Employees with Three Projects
go
USE SoftUni
go
CREATE PROC usp_AssignProject (@employeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @employeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectId)

IF(@employee IS NULL OR @project IS NULL)
BEGIN 
	ROLLBACK
	RAISERROR('Invalid employee id or project id!', 16, 1)
	RETURN
END

DECLARE @employeeProjects INT = (SELECT COUNT(*)FROM EmployeesProjects WHERE EmployeeID = @employeeId)

IF(@employeeProjects >= 3)
BEGIN 
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
END

INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES 
(@employeeId, @projectId)
COMMIT

SELECT * FROM EmployeesProjects WHERE EmployeeID = 2

EXEC usp_AssignProject 2, 1

--22. Delete Employees

CREATE TABLE Deleted_Employees
(
EmployeeID INT PRIMARY KEY,
FirstName VARCHAR (50), 
LastName VARCHAR (50), 
MiddleName VARCHAR (50), 
JobTitle VARCHAR (50), 
DepartmentId INT, 
Salary DECIMAL (15,2)
) 

GO
CREATE TRIGGER tr_Deleted_Employees ON Employees FOR DELETE
AS 
INSERT INTO Deleted_Employees( FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted