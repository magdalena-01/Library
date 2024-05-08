using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data
{

    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserBooks> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author) //each book has one author 
                .WithMany(a => a.Books) //each author can have many books
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Author>()
            .HasKey(a => a.AuthorId);

            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId); //one-to-many book and bookgenre

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId); //one-to-many genre-bookgenre

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book) //each review one book, each book many reviews.
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<UserBooks>()
                .HasKey(ub => ub.UserBookId); //primary key for UserBooks

            modelBuilder.Entity<UserBooks>()
                .HasOne(ub => ub.Book)
                .WithMany(b => b.Users)
                .HasForeignKey(ub =>  ub.BookId);

            base.OnModelCreating(modelBuilder);
        }
           
       
    }
}
