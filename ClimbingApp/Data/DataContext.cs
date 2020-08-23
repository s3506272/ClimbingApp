using Microsoft.EntityFrameworkCore;
using ClimbingApp.Models;

namespace Data
{
    public class ClimbAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ClimbAppContext(DbContextOptions<ClimbAppContext> options)
             : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Boulder> Boulders { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<PullUp> PullUps { get; set; }
        public DbSet<PushUp> PushUps { get; set; }
        public DbSet<HangEdge> HangEdges { get; set; }
        public DbSet<HangWeight> HangWeights { get; set; }

        public DbSet<BoulderAverage> BoulderAverage { get; set; }
        public DbSet<SportAverage> SportAverage { get; set; }
        public DbSet<AllStats> AllStats { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stat>()
    .Property(p => p.RowVersion).IsConcurrencyToken();

            modelBuilder.Entity<PullUp>().HasOne(x => x.Stat).WithMany(x => x.UserPullUPs).HasForeignKey(x => x.StatID);
            modelBuilder.Entity<PushUp>().HasOne(x => x.Stat).WithMany(x => x.UserPushUps).HasForeignKey(x => x.StatID);
            modelBuilder.Entity<HangEdge>().HasOne(x => x.Stat).WithMany(x => x.UserHangEdges).HasForeignKey(x => x.StatID);
            modelBuilder.Entity<HangWeight>().HasOne(x => x.Stat).WithMany(x => x.UserHangWeights).HasForeignKey(x => x.StatID);

            modelBuilder.Entity<HangWeight>().HasOne(x => x.Stat).WithMany(x => x.UserHangWeights).HasForeignKey(x => x.StatID);

            modelBuilder.Entity<Log>().HasOne(x => x.User).WithMany(x => x.Logs).HasForeignKey(x => x.UserID);
            
            modelBuilder.Entity<Log>().HasOne(x => x.Boulder).WithMany(x => x.Logs).HasForeignKey(x => x.BoulderID);
            
            modelBuilder.Entity<Log>().HasOne(x => x.Sport).WithMany(x => x.Logs).HasForeignKey(x => x.SportID);


        }


    }
}
