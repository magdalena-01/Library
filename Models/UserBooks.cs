using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class UserBooks
    {
        [Key]
        public int UserBookId { get; set; }
        public string? AppUser { get; set; }
        

        //foreign key to book 
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
