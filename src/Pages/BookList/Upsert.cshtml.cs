using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
	public class UpsertModel : PageModel
	{
		private readonly DataContext _db;

		public UpsertModel(DataContext db)
		{
			_db = db;
		}

		[BindProperty]
		public Book Book { get; set; }
		
		public async Task<IActionResult> OnGet(int? id)
		{
			Book = new Book();

			if (id is null)
			{
				return Page();
			}

			Book = await _db.Books.FirstAsync(book => book.Id == id);

			if (Book is null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				if (Book.Id == 0)
				{
					_db.Books.Add(Book);
				}
				else
				{
					_db.Books.Update(Book);
				}

				await _db.SaveChangesAsync();

				return RedirectToPage("Index");
			}

			return RedirectToPage();
		}
	}
}