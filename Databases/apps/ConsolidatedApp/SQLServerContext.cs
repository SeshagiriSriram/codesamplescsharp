using csharp.training.congruent.classes;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace ConsolidatedApp
{
    public class SQLServerContext : DbContext
    {
        private readonly string _connectionString = string.Empty;
        public SQLServerContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
             Console.WriteLine($"Connection String: {_connectionString}");   
        }
        public SQLServerContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_connectionString);
        // All Blogs, Posts and Comments
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<RSSBlog> RssBlogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }

        // Cats, Dogs, FarmAnimals and Humans
        public DbSet<Food> Foods => Set<Food>();
        public DbSet<Cat> Cats => Set<Cat>();
        public DbSet<Dog> Dogs => Set<Dog>();
        //public DbSet<FarmAnimal> FarmAnimals => Set<FarmAnimal>();
        public DbSet<Human> Humans => Set<Human>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().
                UseTpcMappingStrategy();

            // Configure relationships
            modelBuilder.Entity<Pet>()
                .HasMany(p => p.Humans)
                .WithMany(h => h.Pets)
                .UsingEntity(j => j.ToTable("HumanPetLinks","training"));

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Food)
                .WithMany()
                .HasForeignKey("FoodId");

            modelBuilder.Entity<Human>()
                .HasOne(h => h.FavoriteAnimal)
                .WithMany()
                .HasForeignKey("FavoriteAnimalId");

            // Optional: Configure precision for FarmAnimal.Value
            //modelBuilder.Entity<FarmAnimal>()
            //  .Property(f => f.Value)
            //.HasPrecision(18, 2);

            /*  Uncomment to allow for custom build....;
             modelBuilder.
    Entity<Blog>().
    Property(b => b.BlogId).
    ValueGeneratedNever();
         */
        }

    }
}
