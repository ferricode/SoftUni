USE SoftUni
----1.	Employee Address
SELECT TOP (5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
   FROM Employees AS e
   JOIN Addresses AS a ON a.AddressID=e.AddressID
   ORDER BY AddressID

--2.	Addresses with Towns
SELECT TOP (50) e.FirstName, e.LastName, t.Name, a.AddressText
   FROM Employees AS e
   JOIN Addresses AS a ON a.AddressID=e.AddressID
   JOIN Towns AS t ON t.TownID=a.TownID
   ORDER BY FirstName, LastName

--3.	Sales Employee
SELECT  e.EmployeeID,FirstName, e.LastName, d.[Name] AS DepartmentName
   FROM Employees AS e
   JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
WHERE e.JobTitle LIKE '%Sales%'
ORDER BY e.EmployeeID

--4.	Employee Departments
--4.	Employee Departments
SELECT TOP (5) e.EmployeeID,FirstName, e.Salary, d.[Name] AS DepartmentName
   FROM Employees AS e
   JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
   WHERE e.Salary > 15000
   ORDER BY d.DepartmentID

--5.	Employees Without Project
SELECT TOP (3) e.EmployeeID,e.FirstName
   FROM Employees AS e
   LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
   WHERE ep.ProjectID IS NULL
   ORDER BY e.EmployeeID

--6.	Employees Hired After
SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
WHERE 
     e.HireDate>'01-01-1999' 
	 AND d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate

--7.	Employees with Project
SELECT TOP (5) e.EmployeeID,e.FirstName,  p.Name AS ProjectName
   FROM Employees AS e
   JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
   LEFT JOIN Projects AS p ON ep.ProjectID=p.ProjectID
  WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8.	Employee 24
SELECT  
		e.EmployeeID,
		e.FirstName,  
		CASE 
			WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			ELSE p.Name
		END AS ProjectName
   FROM Employees AS e
   JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
   LEFT JOIN Projects AS p ON p.ProjectID=ep.ProjectID
  WHERE e.EmployeeID = 24
ORDER BY e.EmployeeID

--9.	Employee Manager

SELECT emp.EmployeeID, emp.FirstName, emp.ManagerID, mng.FirstName
		FROM Employees AS emp
		JOIN Employees AS mng ON mng.EmployeeID=emp.ManagerID
	WHERE emp.ManagerID IN (3,7)
ORDER BY emp.EmployeeID

--10. Employee Summary
SELECT  TOP(50) e.EmployeeID, 
		CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName, 
		CONCAT(mng.FirstName,' ', mng.LastName) AS ManagerName, 
		d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
	JOIN Employees AS mng ON mng.EmployeeID=e.ManagerID
ORDER BY EmployeeID

--11. Min Average Salary

SELECT TOP(1) AVG(Salary) AS AvarageSalary
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
  GROUP BY e.DepartmentID
ORDER BY AvarageSalary

--12. Highest Peaks in Bulgaria
USE Geography

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
	JOIN Mountains AS m ON m.Id=mc.MountainId
	JOIN Peaks AS p ON p.MountainId=m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges

SELECT mc.CountryCode,COUNT(mc.MountainId) AS MountainRanges
	FROM MountainsCountries AS mc
	JOIN Mountains AS m ON m.Id=mc.MountainId
WHERE mc.CountryCode IN('BG','RU','US')
GROUP BY mc.CountryCode
ORDER BY MountainRanges DESC

--14. Countries with Rivers
SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id=cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT ContinentCode, CurrencyCode, Total
  FROM(
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS Total,
	DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
   FROM Countries 
GROUP BY ContinentCode, CurrencyCode
) AS k
  WHERE Ranked = 1 AND Total >1
ORDER BY ContinentCode

--16. Countries Without Any Mountains
SELECT COUNT(*)
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
	WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP(5) CountryName, MAX(p.Elevation) AS HighestPeak, MAX(r.Length) AS LongestRiver
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id=mc.MountainId
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id=cr.RiverId
GROUP BY CountryName
ORDER BY HighestPeak DESC,LongestRiver DESC, CountryName ASC

--18. Highest Peak Name and Elevation by Country

SELECT TOP(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange
FROM (SELECT CountryName, 
	   ISNULL(p.PeakName, '(no highest peak)') AS PeakName, 
	   ISNULL(m.MountainRange, '(no mountain)' ) AS MountainRange,
	   ISNULL(MAX(p.Elevation),0) AS HighestPeak,
	   DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation)DESC) AS Ranked
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id=mc.MountainId
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	GROUP BY CountryName, p.PeakName, m.MountainRange ) AS k
WHERE Ranked=1 
ORDER BY CountryName, PeakName
