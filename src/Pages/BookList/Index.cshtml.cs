using System.Collections.Generic;
using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
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
	}
}