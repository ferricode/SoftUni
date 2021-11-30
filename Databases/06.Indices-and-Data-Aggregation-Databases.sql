--1. Longest Magic Wand
SELECT COUNT(*)
	FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

--3. Longest Magic Wand Per Deposit Groups

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
GROUP BY DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2) DepositGroup
	FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) 

--5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
  WHERE MagicWandCreator IN ('Ollivander family')
GROUP BY DepositGroup

--7. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
  WHERE MagicWandCreator IN ('Ollivander family')
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--8.  Deposit Charge

SELECT DepositGroup, MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator 
ORDER BY MagicWandCreator, DepositGroup

--9. Age Groups
SELECT Result.AgeGroup, COUNT(Result.AgeGroup)
	FROM (
SELECT CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age >60 THEN  '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits) AS Result
GROUP BY Result.AgeGroup

--10. First Letter
SELECT LEFT(FirstName, 1)
	FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

--11. Average Interest 
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
	FROM WizzardDeposits
   WHERE DepositStartDate > '01/01/1985 '
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--12. * Rich Wizard, Poor Wizard
SELECT SUM(Guest.DepositAmount - Host.DepositAmount) As [Difference]
	  FROM WizzardDeposits AS Host
	JOIN WizzardDeposits AS Guest ON Guest.Id +1 = Host.Id

--13. Departments Total Salaries
USE SoftUni

SELECT DepartmentID, SUM(Salary)
	FROM Employees
GROUP BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary)
	FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

--15. Employees Average Salaries

SELECT * INTO MyNewTable
	FROM Employees
  WHERE Salary >30000

DELETE FROM MyNewTable
WHERE ManagerID=42

UPDATE MyNewTable
SET Salary +=5000
WHERE DepartmentID=1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM MyNewTable
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary)
	FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


--17. Employees Count Salaries
SELECT COUNT(*)
	FROM Employees
  WHERE ManagerID IS NULL

--18. *3rd Highest Salary
SELECT DISTINCT k.DepartmentID, k.Salary AS ThirdHighestSalary
FROM(SELECT DepartmentID, Salary,
	DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranked]
	FROM Employees) AS k
WHERE k.Ranked=3

--19. **Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID
    	FROM Employees AS emp
	WHERE Salary > (SELECT AVG(Salary)
						FROM Employees
						WHERE DepartmentID = emp.DepartmentID
					--GROUP BY DepartmentID
					)
ORDER BY DepartmentID