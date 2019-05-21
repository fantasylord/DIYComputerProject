using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.SysEntity;
using Microsoft.EntityFrameworkCore;

namespace DIYComputer.Entity.DBContext
{
    /// <summary>
    /// 数据库上下文管理中心
    /// </summary>

    public class EFDBContext : DbContext
    {
        public DbSet<MenuNode> MenuNodes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<TopicClass> TopicClasses { get; set; }

        public DbSet<CPU> CPUs { get; set; }

        public DbSet<Mainboard> Mainboards { get; set; }

        public DbSet<ROM> ROMs { get; set; }

        public DbSet<Graphyic> Graphyics { get; set; }

        public DbSet<HardDisk> HardDisks { get; set; }

        public DbSet<SSD> SSDs { get; set; }

        public DbSet<CDROM> CDROMs { get; set; }

        public DbSet<Display> Displays { get; set; }

        public DbSet<Case> Cases { get; set; }

        public DbSet<Power> Powers { get; set; }

        public DbSet<CPUHS> CPUHs { get; set; } 

        public DbSet<NetWork>  NetWorks { get; set; } 

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Reply { get; set; }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        //   public DbSet<MovieTest> movieTests { get; set; }
        //public EFDBContext():base("name=xxx"){};

       
        public EFDBContext(DbContextOptions<EFDBContext> options)
            : base(options)
        {
            //Database.IsInMemory();
            Database.EnsureCreated();
          
            //#if DEBUG

            //            try
            //            {
            //                //  Database.Migrate();

            //                Database.EnsureCreated();

            //            }
            //            catch (Exception e)
            //            {

            //                string es = e.ToString();
            //                throw;
            //            }
            //#else 
            //            Database.Migrate();
            //#endif

        }




        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            base.OnModelCreating(_modelBuilder);

            _modelBuilder.ApplyConfiguration(new UserConfiguration());

           

            _modelBuilder.Entity<MenuNode>()
                .HasMany(node => node.Childnodes)
                .WithOne(node => node.ParentNode);

            _modelBuilder.Entity<TopicClass>()
                 .HasMany(node => node.Childnodes)
                 .WithOne(node => node.ParentNode);

            _modelBuilder.Entity<Topic>()
                .HasOne(x => x.TopicClass)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.TopicClassId)
                .OnDelete(DeleteBehavior.SetNull);
                
            _modelBuilder.Entity<Topic>()
                .HasOne(x => x.User)
                .WithMany(x => x.Topics);

            _modelBuilder.Entity<Reply>()
                .HasOne(x => x.Topic)
                .WithMany(x => x.Replies).OnDelete(DeleteBehavior.SetNull);
            _modelBuilder.Entity<Reply>()
                .HasOne(x => x.User)
                .WithMany(x => x.Replies).OnDelete(DeleteBehavior.Cascade);

            

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.User)
                .WithMany().OnDelete(DeleteBehavior.Restrict);
            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.Case)
                .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.CDROM)
                .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.CPU)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.CPUHS)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.Display)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.Graphyic)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.HardDisk)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.Mainboard)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.NetWork)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.Power)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.ROM)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);

            _modelBuilder.Entity<Computer>()
                .HasOne(o => o.SSD)
                  .WithMany().OnDelete(DeleteBehavior.Restrict);


        }








    }
}
