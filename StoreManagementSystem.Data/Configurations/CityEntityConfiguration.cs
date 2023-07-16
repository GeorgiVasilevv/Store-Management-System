using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Data.Configurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(SeedCities());
        }

        private City[] SeedCities()
        {
            ICollection<City> cities = new List<City>();

            City city;

            city = new City()
            {
                Id= 1,
                Title = "Sofia"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 2,
                Title = "Plovdiv"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 3,
                Title = "Varna"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 4,
                Title = "Burgas"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 5,
                Title = "Ruse"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 6,
                Title = "Stara Zagora"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 7,
                Title = "Pleven"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 8,
                Title = "Sliven"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 9,
                Title = "Pazardzhik"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 10,
                Title = "Pernik"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 11,
                Title = "Dobrich"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 12,
                Title = "Shumen"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 13,
                Title = "Veliko Tarnovo"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 14,
                Title = "Haskovo"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 15,
                Title = "Blagoevgrad"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 16,
                Title = "Yambol"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 17,
                Title = "Kazanlak"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 18,
                Title = "Asenovgrad"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 19,
                Title = "Vratsa"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 20,
                Title = "Kyustendil"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 21,
                Title = "Gabrovo"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 22,
                Title = "Targovishte"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 23,
                Title = "Kardzhali"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 24,
                Title = "Vidin"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 25,
                Title = "Razgrad"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 26,
                Title = "Svishtov"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 27,
                Title = "Silistra"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 28,
                Title = "Lovech"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 29,
                Title = "Montana"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 30,
                Title = "Dimitrovgrad"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 31,
                Title = "Dupnitsa"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 32,
                Title = "Smolyan"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 33,
                Title = "Gorna Oryahovitsa"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 34,
                Title = "Petrich"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 35,
                Title = "Gotse Delchev"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 36,
                Title = "Aytos"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 37,
                Title = "Omurtag"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 38,
                Title = "Velingrad"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 39,
                Title = "Karlovo"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 40,
                Title = "Lom"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 41,
                Title = "Panagyurishte"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 42,
                Title = "Botevgrad"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 43,
                Title = "Peshtera"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 44,
                Title = "Rakovski"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 45,
                Title = "Pomorie"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 46,
                Title = "Novi Pazar"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 47,
                Title = "Provadia"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 48,
                Title = "Zlatograd"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 49,
                Title = "Kozloduy"
            };
            cities.Add(city);

            city = new City()
            {
                Id = 50,
                Title = "Bankya"
            };
            cities.Add(city);

            return cities.ToArray();
        }
    }
}
