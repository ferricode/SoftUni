---Inner Join
SELECT 
	*
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID=d.DepartmentID

--
SELECT 
	COUNT(*)
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID=m.EmployeeID

---Left Outer Join
SELECT 
	*
FROM Employees AS e
--LEFT OUTER JOIN Employees AS m ON e.ManagerID=m.EmployeeID
LEFT JOIN Employees AS m ON e.ManagerID=m.EmployeeID

----- More than one condition
SELECT 
	*
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID=m.EmployeeID AND m.EmployeeID=3

--RIGHT OUTER JOIN
SELECT 
	*
FROM Employees AS e
RIGHT OUTER JOIN Employees AS m ON e.ManagerID=m.EmployeeID

--Cartesian Product
SELECT 
	*
FROM Employees, Departments

-- CROSS JOIN
SELECT
	*
 FROM Employees AS e CROSS JOIN Departments AS d

---Problem: Addresses with Towns
SELECT TOP (50)
	e.FirstName,
	e.LastName,
	t.[Name] AS Town,
	a.AddressText
FROM Employees AS e 
JOIN Addresses AS a ON e.AddressID=a.AddressID
JOIN Towns AS t ON a.TownID=t.TownID
ORDER BY e.FirstName, e.LastName

--Problem: Sales Employees
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.Name AS DepartmentName
FROM Employees AS e
--JOIN Departments AS d ON e.DepartmentID=d.DepartmentID AND d.Name='Sales'
--ORDER BY EmployeeID
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
WHERE d.Name='Sales'
ORDER BY EmployeeID

--Problem: Employees Hired After
SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
WHERE 
     e.HireDate>'01-01-1999' 
 --  AND( d.[Name]='Sales' OR d.[Name]='Finance')
	 AND d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate

----Problem: Employees
SELECT 
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName, 
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID=m.EmployeeID
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
order by e.EmployeeID

---SUBQUERIES
SELECT * FROM
(SELECT * FROM Employees WHERE JobTitle LIKE 'Production%') AS e
WHERE e.HireDate BETWEEN '2000-12-31' AND '2002-01-01'

---Problem: Min Avg Salary
SELECT 
	MIN(s.AvgSalary)
FROM
	(SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID) AS s

-- CTE
WITH AvgSalaryCTE(AvgSalary)
AS
	(SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID)

SELECT MIN(AvgSalary) FROM AvgSalaryCTE

-----Common Table Expressions (CTE)

WITH AvgSalaryCTE(AvgSalary, DepartmentName)
AS
(SELECT 
		AVG(Salary) AS AvgSalary 
		,d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
GROUP BY  d.[Name])

SELECT * FROM AvgSalaryCTE AS a WHERE a.AvgSalary=
(SELECT MIN(AvgSalary) FROM AvgSalaryCTE)
