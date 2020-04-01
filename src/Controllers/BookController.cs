using System.Linq;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
	[Route("api/Book")]
	[ApiController]
	public class BookController : Controller
	{
		private readonly DataContext _db;

		public BookController(DataContext db)
		{
			_db = db;
		}
		
		[HttpGet]
		public IActionResult GetAll()
		{
			return Json(new {data = _db.Books.ToList()});
		}
	}
}