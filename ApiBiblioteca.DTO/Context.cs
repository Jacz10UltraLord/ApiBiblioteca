using ApiBiblioteca.DTO.Models;
using System.Data.Entity;

namespace ApiBiblioteca.DTO
{
    public class Context : DbContext
    {
        public static Context context = null;

        public Context() : base("Context") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public static Context Create()
        { 
            return new Context();
        }
    }
}