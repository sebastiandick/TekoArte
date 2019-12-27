
namespace apiTekoArte.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TekoArte
    {
        [Key]
        public int ArtID { get; set; }
        [Required]
        public string Painting { get; set; }
        [Required]
        public string Vase { get; set; }
        [Required]
        public string Plate { get; set; }
        [Required]
        public string Others { get; set; }
    }
}