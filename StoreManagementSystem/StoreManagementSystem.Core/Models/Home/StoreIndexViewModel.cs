namespace StoreManagementSystem.Core.ViewModels.Home
{
    public class StoreIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
        public decimal? Rating { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
