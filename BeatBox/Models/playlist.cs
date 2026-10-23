using System.ComponentModel.DataAnnotations;

namespace BeatBox.Models
{
    public class playlist
    {
        public int PlaylistId { get; set; }
        [Required]
        
        public required string Name { get; set; } 
        
        public string? Genre { get; set; }

        public DateTime? CreatedDate { get; set; } 

        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
 

