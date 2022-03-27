using System.ComponentModel.DataAnnotations;

namespace MVCh.Models
{
    public class Thread
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public IEnumerable<Post>? Posts { get; set; }
        public int BoardId { get; set; }
    }
}
