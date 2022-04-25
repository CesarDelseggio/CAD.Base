using CAD.Base.DataAccess.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CAD.Base.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Log> Logs { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        //Aqui podemos cargar los datos iniciales de la aplicación, si los tiene.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}
