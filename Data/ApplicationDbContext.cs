using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ListaZakupowMVC.Models;

namespace ListaZakupowMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ListaZakupowMVC.Models.ListaZakupow> ListaZakupow { get; set; } = default!;
    }
}
