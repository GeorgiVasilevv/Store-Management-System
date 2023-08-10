using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ProvinceEntityConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasData(SeedPronvinces());
        }

        private Province[] SeedPronvinces()
        {
            ICollection<Province> provinces = new List<Province>();

            Province province;

            province = new Province()
            {
                Id = 1,
                Title = "Blagoevgrad"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 2,
                Title = "Burgas"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 3,
                Title = "Dobrich"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 4,
                Title = "Gabrovo"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 5,
                Title = "Haskovo"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 6,
                Title = "Kardzhali"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 7,
                Title = "Kyustendil"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 8,
                Title = "Lovech"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 9,
                Title = "Montana"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 10,
                Title = "Pazardzhik"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 11,
                Title = "Pernik"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 12,
                Title = "Pleven"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 13,
                Title = "Plovdiv"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 14,
                Title = "Razgrad"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 15,
                Title = "Ruse"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 16,
                Title = "Shumen"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 17,
                Title = "Silistra"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 18,
                Title = "Sliven"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 19,
                Title = "Smolyan"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 20,
                Title = "Sofia City"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 21,
                Title = "Sofia (province)"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 22,
                Title = "Stara Zagora"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 23,
                Title = "Targovishte"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 24,
                Title = "Varna"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 25,
                Title = "Veliko Tarnovo"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 26,
                Title = "Vidin"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 27,
                Title = "Vratsa"
            };
            provinces.Add(province);

            province = new Province()
            {
                Id = 28,
                Title = "Yambol"
            };
            provinces.Add(province);

            return provinces.ToArray();
        }
    }
}
