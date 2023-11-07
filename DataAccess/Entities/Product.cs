using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess.Entities
{
	public class Product
	{
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public List<UserProduct> UserProducts { get; set; }

        public List<SaleProduct> SaleProducts { get; set; }
    }
}
