using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCh.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        //public string ImageTitle { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload file")]
        public IFormFile ImageFile { get; set; }
        public int PostId { get; set; }
    }
}
