using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string? Title { get; set; }
        public int? YearPublished { get; set; }
        public int? NumPages { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "Please select an author")]
        public int AuthorId { get; set; } //foreign key 

        [ForeignKey("AuthorId")]
        public Author ?Author { get; set; }
        public string FrontPage { get; set; } // Path/URL to the cover image
        public string DownloadUrl { get; set; } // Path/URL to the electronic version
        public ICollection<BookGenre> ?BookGenres { get; set; }
        public ICollection<Review> ?Reviews { get; set; }
        public ICollection<UserBooks> ?Users { get; set; }

        [NotMapped]
        public double AverageRating { get; set; }



    }
}
