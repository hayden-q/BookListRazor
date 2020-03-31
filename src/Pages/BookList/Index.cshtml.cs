using System.Collections.Generic;
using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
	public class IndexModel : PageModel
	{
		private readonly DataContext _db;

		public IndexModel(DataContext db)
		{
			_db = db;
		}
		
		public IEnumerable<Book> Books { get; set; }
		
		public async Task OnGet()
		{
			Books = await _db.Books.ToListAsync();
		}

		public async Task<IActionResult> OnPostDelete(int id)
		{
			var bookFromDb = await _db.Books.FindAsync(id);

			if (bookFromDb is null)
			{
				return NotFound();
			}

			_db.Books.Remove(bookFromDb);
			await _db.SaveChangesAsync();

			return RedirectToPage("Index");
		}
	}
}