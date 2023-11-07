using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Business.Models
{
	public class ProductModel
	{
		public int Id { get; set; }

		[DisplayName("Product Name")]
		[Required(ErrorMessage = "{0} is required")]
		public string ProductName { get; set; }

		public string ProductDescription { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
