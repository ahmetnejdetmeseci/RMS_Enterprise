using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class DbDemoController : Controller
	{

		private readonly Db _db;

		public DbDemoController(Db db)
		{
			_db = db;
		}

		public IActionResult Seed()
		{
			_db.Users.Add(new User()
			{
				UserName = "Adnan",
				Email = "+905535078285",
				Password = "12345",
				
			});

			_db.Users.Add(new User()
			{
				UserName = "Kefir",
				Email = "+905534800978",
				Password = "2468",

			});

			_db.Products.Add(new Product()
			{
				Price = 129.0,
				ProductName = "Borek",
				ProductDescription = "Peynirli Borek",
				Quantity = 42,
				
			});

			_db.Products.Add(new Product()
			{
				Price = 240.0,
				ProductName = "Borek",
				ProductDescription = "Kiymali Borek",
				Quantity = 14,
				
			});

			_db.SaveChanges();

			return Content("User seed is successful");
		}

		public IActionResult Index()
		{
			return View();
		}
	}



}
