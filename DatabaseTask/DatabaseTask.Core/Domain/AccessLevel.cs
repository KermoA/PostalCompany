using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class AccessLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessLevelId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }  

        public int Level { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        [StringLength(30)]
        public string AccessType { get; set; }

        [StringLength(100)]
        public string? Comment { get; set; }
    }
}
