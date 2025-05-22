using System.ComponentModel.DataAnnotations;

namespace RedditPoster.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsApprovedByUser { get; set; }

        public bool IsApprovedByAI { get; set; }
    }
}
