using BookListRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		
		public DbSet<Book> Books { get; set; }
	}
}