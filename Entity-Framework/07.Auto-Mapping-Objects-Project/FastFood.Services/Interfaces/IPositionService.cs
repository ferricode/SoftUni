using FastFood.Services.DTO.Position;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services
{
    public interface IPositionService
    {
        ICollection<EmployeeRegisterPositionsAvailable> GetPositionsAvailable();

    }
}
