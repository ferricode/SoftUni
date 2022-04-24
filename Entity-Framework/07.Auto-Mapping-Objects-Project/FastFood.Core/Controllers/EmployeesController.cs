namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Position;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IMapper mapper;

        private readonly IPositionService positionService;
        private readonly IEmployeeService employeeService;

        public EmployeesController(IMapper mapper, IPositionService positionService, 
            IEmployeeService employeeService)
        {
            this.mapper = mapper;
            
            this.positionService = positionService;
            this.employeeService = employeeService;
        }

        public IActionResult Register()
        {
            ICollection<EmployeeRegisterPositionsAvailable> positionsDto =
                this.positionService.GetPositionsAvailable();

            List<RegisterEmployeeViewModel> regViewModel = this.mapper
                            .Map<ICollection<EmployeeRegisterPositionsAvailable>,
                                ICollection<RegisterEmployeeViewModel>>(positionsDto)
                            .ToList();

            return this.View(regViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Register");
            }
            RegisterEmployeeDto employeeDto = this.mapper.Map<RegisterEmployeeDto>(model);

            this.employeeService.Register(employeeDto);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllEmployeesDto> employeesDtos = this.employeeService.All();

            List<EmployeesAllViewModel> employeesViewmodels = this.mapper
                .Map<ICollection<ListAllEmployeesDto>, ICollection<EmployeesAllViewModel>>(employeesDtos)
                .ToList();

            return this.View(employeesDtos);
        }
    }
}
