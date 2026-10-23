using System.ComponentModel.DataAnnotations;

namespace BeatBox.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Required]
        public required string Title { get; set; } 
        public required string Artist { get; set; } 
        public int? DurationSeconds { get; set; }

        public int? PlaylistId { get; set; }

        public playlist Playlist { get; set; }
    }
}
