namespace EmployeeArrivalTracker.Data
{

    using Models;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class EmployeeArrivalTrackerDbContext : DbContext
    {
        public EmployeeArrivalTrackerDbContext()
            : base("DefaultConnection")
        {
        }

        public static EmployeeArrivalTrackerDbContext Create()
        {
            return new EmployeeArrivalTrackerDbContext();
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Token> Tokens { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                   .HasOptional(c => c.Manager)
                   .WithMany()
                   .HasForeignKey(c => c.ManagerId);
        }
    }

}
