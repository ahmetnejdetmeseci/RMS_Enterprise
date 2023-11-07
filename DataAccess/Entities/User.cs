using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess.Entities
{
	public class User
	{
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public List<UserProduct> UserProducts { get; set; }
    }
}
