using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Employee;
using FastFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService

    {
        private readonly IMapper mapper;
        private readonly FastFoodContext dbContext;

        public EmployeeService( FastFoodContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void Register(RegisterEmployeeDto dto)
        {
            Employee employee = this.mapper.Map<Employee>(dto);

            this.dbContext.Employees.Add(employee);
            this.dbContext.SaveChanges();
        }
        public ICollection<ListAllEmployeesDto> All() => dbContext
            .Employees
            .ProjectTo<ListAllEmployeesDto>(this.mapper.ConfigurationProvider)
            .ToList();
    }
}
