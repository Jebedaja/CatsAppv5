using CatsApp.Models;
using CatsForum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatsApp.Data                                                      
{
    public class ApplicationDbContext : IdentityDbContext                   // Klasa ApplicationDbContext dziedziczy po IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)         // Konstruktor klasy ApplicationDbContext
        {
        }

        public DbSet<CatsModelEntity> CatsModelEntity { get; set; }     // reprezetuje tabelę CatsModelEntity w bazie danych
        public DbSet<Comment> Comments { get; set; }      // to samo dla tabeli Comments
    }
}
