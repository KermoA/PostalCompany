using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class JobTitle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobTitleId { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        public decimal SalaryLevel { get; set; }

        [StringLength(100)]
        public string? Comment { get; set; }
        [ForeignKey("WorkTime")]
        public int WorkTimeId { get; set; }

        public WorkTime WorkTime { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
