namespace BuisnessSystem.DataAccess
{
    using BuisnessSystem.Models;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }

        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journal>().HasIndex(j => j.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.TelephoneNumber).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(j => j.TelephoneNumber).IsUnique();
        }
    }
}