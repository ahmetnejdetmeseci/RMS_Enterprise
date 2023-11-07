using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess.Entities
{
	public class SaleProduct
	{
        [Key]
        [Column(Order = 0)]
		public int ProductId { get; set; }

        public Product Product { get; set; }

        [Key]
        [Column(Order = 1)] 
        public int SaleId { get; set; }

        public Sale Sale { get; set; }




        public double Price { get; set; }

        public int Quantity { get; set; }

        public double PriceTotal { get; set;}
    }
}
