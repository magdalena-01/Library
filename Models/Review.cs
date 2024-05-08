using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        //foreign key to book 
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string? AppUser { get; set; }
        public string? Comment { get; set; }

        [Range(1, 10, ErrorMessage = "The rating must be between 1 and 10.")]
        public int Rating { get; set; }

    }
}
