using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Author
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public ICollection<Book> ?Books { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

    }
}
