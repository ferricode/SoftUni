/****** Script for SelectTopNRows command from SSMS  ******/
--Ranking
SELECT TOP (10) 
	   ROW_NUMBER() OVER (ORDER BY Salary) AS RowNumber
	  ,RANK() OVER (ORDER BY Salary) AS RANK
	  ,DENSE_RANK() OVER (ORDER BY Salary) AS DENSE_RANK
	  ,NTILE(2) OVER (ORDER BY FirstName) AS NTILE

	  ,[EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[Salary]
    FROM [SoftUni].[dbo].[Employees]
	ORDER BY Salary
--Wildcards

SELECT TOP (1000) [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName]
      ,[JobTitle]
      ,[DepartmentID]
      ,[ManagerID]
      ,[HireDate]
      ,[Salary]
      ,[AddressID]
FROM [SoftUni].[dbo].[Employees]
--WHERE FirstName LIKE 'Ro%'
WHERE FirstName LIKE '%ko%'


