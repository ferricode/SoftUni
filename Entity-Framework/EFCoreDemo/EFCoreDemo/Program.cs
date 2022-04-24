using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Employees, EmployeeDTO>()
            .ForMember(d => d.NumberOfProjects,
                s => s.MapFrom(opt => opt.EmployeesProjects.Count)));

            var mapper = config.CreateMapper();

            using (var dbContext = new SoftUniContext())
            {
                //SelectMany
                var employees = await dbContext.Employees
                    .Include(e => e.Address)
                    .ThenInclude(a => a.Town)
                    .Where(e => e.EmployeeId > 20)
                    .ProjectTo<EmployeeDTO>(config)
                    .ToListAsync();

                var employeeDto = employees.FirstOrDefault();
                employeeDto.DepartmentName = "Production";

                var employee = mapper.Map<Employees>(employeeDto);




                //var employees = await dbContext.Employees
                //    .Where(e => e.Department.Name == "Production")
                //    //.SelectMany(e => e.EmployeesProjects)
                //    .SelectMany(e => e.EmployeesProjects, (p,c)=> new { p.FirstName, c.Project.Name})
                //    //.Select(p=>p.Project.Name)
                //    .Distinct()
                //    .ToListAsync();


                //Grouping
                //var employees = await dbContext.Employees
                //    .GroupBy(e => e.Department.Name)
                //    .Select(grp => new
                //    {
                //        DeepartmentName = grp.Key,
                //        averageSalary = grp.Average(e => e.Salary),
                //        MinSalary = grp.Min(e=>e.Salary),
                //        MaxSalary = grp.Max(e => e.Salary)

                //    })
                //    .ToListAsync();

                //Join
                //var employees = await dbContext.Employees
                //    .Join(dbContext.Departments,
                //    e => e.DepartmentId,
                //    d => d.DepartmentId,
                //    (e, d) => new
                //    {
                //        e.FirstName,
                //        d.Name
                //    })
                //    .Where(d=>d.Name == "Marketing")
                //    .ToListAsync();

                //Employees employee = await dbContext.Employees.FindAsync(1);

                //var employees =  await dbContext.Employees
                //    .Where(e => e.Department.Name == "Marketing")
                //    .Select(e => new
                //    {
                //        Name = $"{e.FirstName} {e.LastName}",
                //        Department = e.Department.Name
                //    }).ToListAsync();
                //.ToQueryString();

                //Agregation
                //var avarageSalary = await dbContext.Employees
                //    .Where(e => e.Department.Name == "Marketing")
                //   //.Select(s => s.Salary)
                //    .AverageAsync(s => s.Salary);
                //Console.WriteLine(avarageSalary);

                //foreach (var item in employees)
                //{
                //    Console.WriteLine(item);
                //    //Console.WriteLine($"{item.Name}, {item.Department}");
                //}

                //Console.WriteLine($"{employee.FirstName} {employee.LastName}");

            }
        }
    }
}
