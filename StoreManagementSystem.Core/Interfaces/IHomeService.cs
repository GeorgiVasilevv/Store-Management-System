using StoreManagementSystem.Core.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Core.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<StoreIndexViewModel>> GetThreeHighestRatingStores();
        Task<IEnumerable<StoreIndexViewModel>> GetTenMostRecentStores();
    }
}
