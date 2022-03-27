using System.ComponentModel.DataAnnotations;

namespace MVCh.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public IEnumerable<Thread> Threads { get; set; }
    }
}
