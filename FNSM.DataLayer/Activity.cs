using System.ComponentModel.DataAnnotations;

namespace FNSM.DataLayer
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
