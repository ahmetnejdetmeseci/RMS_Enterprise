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
	public class UserProduct
	{
		[Key]
		[Column(Order = 0)]
		public int UserId { get; set; }

        public User User { get; set; }

		[Key]
		[Column(Order = 1)]
		public int ProductId { get; set; }

		public Product Product { get; set; }

        public int AddedQuantity { get; set; }

        public double TotalPrice { get; set; }

    }
}
