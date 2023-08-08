using StoreManagementSystem.Core.Models.ViewModels.Store.Interfaces;

namespace StoreManagementSystem.Extensions
{
    public static class ViewModelsExtensions
    {
        public static string GetUrlInformation(this IStoreDetailsModel detailsModel)
        {
            return detailsModel.Title.Replace(" ", "-");
        }
    }
}
