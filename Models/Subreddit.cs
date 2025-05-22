using System.ComponentModel.DataAnnotations;

namespace RedditPoster.Models
{
    public class MessageTarget
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subreddit { get; set; } = default!;

        [Required]
        public string Slug { get; set; } = default!;

        public bool IsActive { get; set; } = true;

        public DateTime dtCreated { get; set; } = DateTime.Now;

        public DateTime? LastSentAt { get; set; } // nullable, set when a message is sent

        public int SentCounter { get; set; } = 0; // number of messages sent to this forum
    }
}
