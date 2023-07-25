using System.ComponentModel.DataAnnotations;

namespace FNSM.DataLayer
{
    public class Activity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Description should be between 10 and 50 characters long.", MinimumLength = 10)]
        public string? Description { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Elaboration should be between 10 and 255 characters long.", MinimumLength = 10)]
        public string? Elaboration { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
