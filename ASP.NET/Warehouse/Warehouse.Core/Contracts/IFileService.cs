using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Core.Contracts
{
    public interface IFileService
    {
        Task SaveFileAsync(ApplicationFile file);
    }
}
