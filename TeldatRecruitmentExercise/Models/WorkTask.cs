
using System.ComponentModel.DataAnnotations;

namespace TeldatRecruitmentExercise.Models
{
    public class WorkTask
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddDateTime { get; set; }
    }
}
