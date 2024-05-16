using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class BranchOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchOfficeId { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public int RegistryNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string ContactPerson { get; set; }

        public int ContactPhoneNumber { get; set; }

        [StringLength(30)]
        public string ContactEmail { get; set; }

        [StringLength(100)]
        public string? Comment { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
