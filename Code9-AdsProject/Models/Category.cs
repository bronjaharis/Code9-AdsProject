using System.ComponentModel.DataAnnotations;

namespace Code9_AdsProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
    }
}
