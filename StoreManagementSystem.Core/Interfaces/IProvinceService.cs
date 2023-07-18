using StoreManagementSystem.Core.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Core.Interfaces
{
    public interface IProvinceService
    {
        Task<IEnumerable<StoreSelectProvinceFormModel>> GetAllProvincesOrderedAsync();
        Task<bool> ExistsByIdAsync(int id);
    }
}
