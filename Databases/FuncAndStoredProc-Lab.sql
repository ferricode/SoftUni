--Problem: Salary Level Function
CREATE FUNCTION udf_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10);
	IF (@Salary < 30000)
		SET @result='Low';
	ELSE IF(@Salary <=50000)
		SET @result = 'Average';
	ELSE
		SET @result = 'High';
	RETURN @result;
END

---
SELECT *, dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees
