using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTask.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
            : base(options) { }


        public DbSet<Company> Company { get; set; }
        public DbSet<BranchOffice> BranchOffice { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeesChild> EmployeesChild { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<AccessLevel> AccessLevel { get; set; }
        public DbSet<Vacation> Vacation { get; set; }
        public DbSet<SickLeave> SickLeave { get; set; }
        public DbSet<HealthCheck> HealthCheck { get; set; }
        public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<WorkTime> WorkTime { get; set; }
        public DbSet<BorrowedItem> BorrowedItems { get; set;}
        public DbSet<Hint> Hint { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Vacations)
                .WithOne()
                .HasForeignKey(v => v.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SickLeaves)
                .WithOne()
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HealthChecks)
                .WithOne()
                .HasForeignKey(h => h.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithOne()
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Children)
                .WithOne()
                .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkTimes)
                .WithOne()
                .HasForeignKey(w => w.EmployeeId);

            modelBuilder.Entity<BranchOffice>()
                .HasMany(b => b.Departments)
                .WithOne(d => d.BranchOffice)
                .HasForeignKey(d => d.BranchOfficeId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.BranchOffices)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<WorkTime>()
                .HasMany(w => w.JobTitles)
                .WithOne(j => j.WorkTime)
                .HasForeignKey(j => j.WorkTimeId);

            modelBuilder.Entity<AccessLevel>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.AccessLevels)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BorrowedItem>()
                .HasOne(b => b.Employee)
                .WithMany(e => e.BorrowedItems)
                .HasForeignKey(b => b.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobTitle)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobTitleId)
                .OnDelete(DeleteBehavior.Restrict);

        }




    }
}
