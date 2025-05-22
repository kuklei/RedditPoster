using System.ComponentModel.DataAnnotations;

namespace RedditPoster.Models
{
    public class MessageTarget
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subreddit { get; set; } = default!;

        public int MessageId { get; set; }
    }
}
