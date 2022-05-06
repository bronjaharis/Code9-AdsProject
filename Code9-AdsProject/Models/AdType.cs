using System.ComponentModel.DataAnnotations;

namespace Code9_AdsProject.Models
{
    public class AdType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
