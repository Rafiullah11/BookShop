using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccessLayer
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
