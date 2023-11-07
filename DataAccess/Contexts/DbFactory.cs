using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
	public class DbFactory : IDesignTimeDbContextFactory<Db>
	{
		public Db CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<Db>();
			optionsBuilder.UseMySQL("server=127.0.0.1; database=ResourceManagementEnterpriseDB; user id=root; password=;");

			return new Db(optionsBuilder.Options);
		}
	}
}
