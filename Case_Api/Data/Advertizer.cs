using System.ComponentModel.DataAnnotations;

namespace Case_Api.Data
{
    public class Advertizer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
