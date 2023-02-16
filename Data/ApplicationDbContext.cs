using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoundEffect.Data;

namespace SoundEffect.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SoundEffect.Data.Items> Items { get; set; }
        public DbSet<SoundEffect.Data.Genre> Genre { get; set; }
        public DbSet<SoundEffect.Data.ShoppingCart> ShoppingCart { get; set; }
    }
}