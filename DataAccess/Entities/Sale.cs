using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess.Entities
{
	public class Sale
	{
		public int Id { get; set; }

        public List<SaleProduct> SaleProducts { get; set; }

    }
}
