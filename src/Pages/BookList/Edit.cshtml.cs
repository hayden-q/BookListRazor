using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
	public class EditModel : PageModel
	{
		private readonly DataContext _db;

		public EditModel(DataContext db)
		{
			_db = db;
		}
		
		[BindProperty]
		public Book Book { get; set; }
		
		public async Task OnGet(int id)
		{
			Book = await _db.Books.FindAsync(id);
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				var bookFromDb = await _db.Books.FindAsync(Book.Id);

				bookFromDb.Name = Book.Name;
				bookFromDb.Author = Book.Author;
				bookFromDb.ISBN = Book.ISBN;

				await _db.SaveChangesAsync();

				return RedirectToPage("Index");
			}

			return RedirectToPage();
		}
	}
}