using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [ForeignKey("BranchOffice")]
        public int BranchOfficeId { get; set; }

        public BranchOffice BranchOffice { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string ContactPerson { get; set; }

        public int ContactPhoneNumber { get; set; }

        [StringLength(30)]
        public string ContactEmail { get; set; }

        [StringLength(100)]
        public string? Comment { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
