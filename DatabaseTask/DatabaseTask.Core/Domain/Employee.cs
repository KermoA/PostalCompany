using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public int PersonalIdentificationNumber { get; set; }

        [StringLength(100)]
        public string ContactAddress { get; set; }

        public int ContactPhoneNumber { get; set; }

        [StringLength(30)]
        public string ContactEmail { get; set; }

        public DateTime AtWorkSince { get; set; }

        public DateTime? AtWorkUntil { get; set; }

        [ForeignKey("JobTitle")]
        public int JobTitleId { get; set; }

        public JobTitle JobTitle { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        [StringLength(100)]
        public string? Comment { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Vacation> Vacations { get; set; }
        public ICollection<SickLeave> SickLeaves { get; set; }
        public ICollection<HealthCheck> HealthChecks { get; set; }
        public ICollection<AccessLevel> AccessLevels { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<EmployeesChild> Children { get; set; }
        public ICollection<BorrowedItem> BorrowedItems { get; set; }
        public ICollection<WorkTime> WorkTimes { get; set; }
    }
}
