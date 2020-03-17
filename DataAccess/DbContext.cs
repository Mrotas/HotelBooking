using DataAccess.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DatabaseContext = System.Data.Entity.DbContext;

namespace DataAccess
{
    public class DbContext : DatabaseContext
    {
        public DbContext() : base("name=DbContext")
        {
            Database.SetInitializer<DbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomOption> RoomOption { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}