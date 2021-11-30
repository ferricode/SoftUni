using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            //Problem 15
            //string result = RemoveTown(db);

            //Problem 12
            //string result = IncreaseSalaries(db);


            //Problem 09

            //string result = GetEmployee147(db);
            //Problem 10
            //string result = GetDepartmentsWithMoreThan5Employees(db);

            //Problem 11
            //string result = GetLatestProjects(db);

            //Problem 13
            //string result = GetEmployeesByFirstNameStartingWithSa(db);
            string result = DeleteProjectById(db);

            //Problem 14

            //Problem 07
            // string result = GetEmployeesInPeriod(db);
            //Problem 06
            //string result = AddNewAddressToEmployee(db);

            //Problem 05
            //string result = GetEmployeesFromResearchAndDevelopment(db);

            //Problem 04
            //string result = GetEmployeesWithSalaryOver50000(db);
            Console.WriteLine(result);
        }
        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
               .Employees
               .Select(e => new
               {
                   e.EmployeeId,
                   e.FirstName,
                   e.LastName,
                   e.MiddleName,
                   e.JobTitle,
                   e.Salary
               })
               .OrderBy(e => e.EmployeeId)
               .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            //Employee[] employees = context
            //    .Employees
            //    .ToArray()
            //    .Where(e => e.Salary > 50000)
            //    .OrderBy(e => e.FirstName)
            //    .ToArray();

            var employees = context
               .Employees
               .Where(e => e.Salary > 50000)
               .OrderBy(e => e.FirstName)
               .Select(e => new
               {
                   e.FirstName,
                   e.Salary
               })
               .ToArray();


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Pronlem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakovEmployee = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            string[] allEmployeesAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            return String.Join(Environment.NewLine, allEmployeesAddresses);
        }

        //Problem 07 
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
               .Select(e => new
               {
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   ManagerFirstName = e.Manager.FirstName,
                   ManagerLastName = e.Manager.LastName,
                   Projects = e.EmployeesProjects.Select(ep => new
                   {
                       ProjectName = ep.Project.Name,
                       ProjectStartDate = ep.Project.StartDate,
                       ProjectEndDate = ep.Project.EndDate
                   })
               }).Take(10);

            StringBuilder employeeManagerResult = new StringBuilder();

            foreach (var employee in employees)
            {
                employeeManagerResult.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.ProjectEndDate.HasValue ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    employeeManagerResult.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return employeeManagerResult.ToString().TrimEnd();
        }

        //Problem 08 
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                    .Addresses
                    .Select(a => new
                    {
                        a.AddressText,
                        TownName = a.Town.Name,
                        EmployeeCount = a.Employees.Count
                    })
                    .OrderByDescending(a => a.EmployeeCount)
                    .ThenBy(a => a.TownName)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 09

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            const int SearchedEmployeeId = 147;

            var employeeToGet = context
                    .Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        e.EmployeeId,
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        Projects = e.EmployeesProjects.Select(ep => new
                        {
                            ProjectName = ep.Project.Name
                        })
                    })
                    .SingleOrDefault(e => e.EmployeeId == SearchedEmployeeId);

            sb.AppendLine($"{employeeToGet.FirstName} {employeeToGet.LastName} - {employeeToGet.JobTitle}");


            foreach (var p in employeeToGet.Projects.OrderBy(ep => ep.ProjectName))
            {
                sb.AppendLine($"{p.ProjectName}");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsWithEmployees = context.Departments
                       .Where(d => d.Employees.Count > 5)
                       .OrderBy(d => d.Employees.Count)
                       .ThenBy(d => d.Name)
                       .Select(d => new
                       {
                           DepartmentName = d.Name,
                           ManagerFirstName = d.Manager.FirstName,
                           ManagerLastName = d.Manager.LastName,
                           Employees = d.Employees
                               .Select(e => new
                               {
                                   e.FirstName,
                                   e.LastName,
                                   e.JobTitle
                               })
                               .OrderBy(e => e.FirstName)
                               .ThenBy(e => e.LastName)
                               .ToList()
                       })
                       .ToList();



            var sb = new StringBuilder();

            foreach (var d in departmentsWithEmployees)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var emp in d.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }
        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().Trim();
        }
        //Problem 12

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            IQueryable<Employee> employeesToIncreaseSalary = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                           e.Department.Name == "Tool Design" ||
                           e.Department.Name == "Marketing" ||
                           e.Department.Name == "Information Services");

            foreach (Employee employee in employeesToIncreaseSalary)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();

            var employeesToDisplay = employeesToIncreaseSalary
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.Salary
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToArray();

            foreach (var e in employeesToDisplay)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle,
                                e.Salary
                            })
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().Trim();


        }
        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {

            var proToDelete = context.Projects.Find(2);

            var employeesProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            foreach (var ep in employeesProjects)
            {
                context.EmployeesProjects.Remove(ep);

            }

            var resultProjects = context.Projects
               .Take(10)
               .Select(p => p.Name)
               .ToList();

            var sb = new StringBuilder();

            foreach (var p in resultProjects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().Trim();

            context.Projects.Remove(proToDelete);
            context.SaveChanges();
        }
       
        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            Address[] seattleAddresses = context
                    .Addresses
                    .Where(a => a.Town.Name == "Seattle")
                    .ToArray();

            Employee[] employeesInSeattle = context
                .Employees
                .ToArray()
                .Where(e => seattleAddresses.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (Employee employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(seattleAddresses);

            Town seattleTown = context
                .Towns
                .First(t => t.Name == "Seattle");
            context.Towns.Remove(seattleTown);

            context.SaveChanges();

            return $"{seattleAddresses.Length} addresses in Seattle were deleted";


        }

    }
}