using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Albaque_2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(@"Persist Security Info=False;Integrated Security=true;Initial Catalog=Albaque_2;server=PC954")
        {
        }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Complexite> Complexites { get; set; }
        public DbSet<Technologie> Technologies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Tache> Taches { get; set; }

        public DbSet<Chiffrage> Chiffrages { get; set; }
        public DbSet<Chiffrage_Tache> Chiffrages_Taches { get; set; }
    }
}