using System.ComponentModel.DataAnnotations;

namespace Student.Models.Details
{
    public class SchoolStudentDetails
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
