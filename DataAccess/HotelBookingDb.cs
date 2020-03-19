using DataAccess.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DatabaseContext = System.Data.Entity.DbContext;

namespace DataAccess
{
    public class HotelBookingDb : DatabaseContext
    {
        public HotelBookingDb() : base("name=HotelBookingDb")
        {
            Database.SetInitializer<HotelBookingDb>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomOption> RoomOption { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
