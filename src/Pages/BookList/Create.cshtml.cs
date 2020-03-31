using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
	public class CreateModel : PageModel
	{
		private readonly DataContext _db;

		public CreateModel(DataContext db)
		{
			_db = db;
		}
		
		[BindProperty]
		public Book Book { get; set; }
		
		public void OnGet()
		{
			
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				await _db.Books.AddAsync(Book);
				await _db.SaveChangesAsync();

				return RedirectToPage("Index");
			}
			else
			{
				return Page();
			}
		}
	}
}