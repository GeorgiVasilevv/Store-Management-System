using StoreManagementSystem.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class ClothesSize
    {
        //TODO Add Comments
        public ClothesSize()
        {
            Clothes = new List<Clothing>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public ClothingSize Size { get; set; }

        public ICollection<Clothing> Clothes { get; set; }
    }
}
