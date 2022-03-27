using System.ComponentModel.DataAnnotations;

namespace MVCh.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? TextContent { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<int>? Links { get; set; }
        public IEnumerable<Image>? PostImages { get; set; }
        public int ThreadId { get; set; }
    }
}
