using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		public async Task<IActionResult> GetAll()
		{
			return Json(new {data = await _db.Books.ToListAsync()});
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var bookFromDb = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);

			if (bookFromDb == null)
			{
				return Json(new { success = false, message = "Couldn't find book to delete" });
			}

			_db.Books.Remove(bookFromDb);
			await _db.SaveChangesAsync();

			return Json(new { success = true, message = "Book deleted successfully" });
		}
	}
}