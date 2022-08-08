using CRUD_TRY.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TRY.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
