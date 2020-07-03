using Books.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {

        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(

                new Author()
                {
                    Id = Guid.Parse("681b93e7-9c12-4abb-83bd-8f686717f31a"),
                    FirstName = "George",
                    LastName = "Martin"
                },
                new Author()
                {
                    Id = Guid.Parse("03634c2d-5279-4dc1-8a92-b32d33408778"),
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author()
                {
                    Id = Guid.Parse("aa675ba5-f906-45e1-9d2d-b1293ff82f3e"),
                    FirstName = "James",
                    LastName = "Elroy"
                },
                new Author()
                {
                    Id = Guid.Parse("be59b3c4-d918-46df-a7cd-17db5b68a0b2"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
                );

            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    Id = Guid.Parse("e49ba68c-8c1d-479e-bb6c-de9fab807bde"),
                    AuthorId = Guid.Parse("681b93e7-9c12-4abb-83bd-8f686717f31a"),
                    Title = "The Winds of Winter",
                    Description = "The book that seems impossible to write"
                },
                new Book
                {
                    Id = Guid.Parse("49174169-e8e6-4955-aaca-23547750bcc3"),
                    AuthorId = Guid.Parse("03634c2d-5279-4dc1-8a92-b32d33408778"),
                    Title = "A Game of Thrones",
                    Description = "A Game of Thrones is the first novel..."
                },
                new Book
                {
                    Id = Guid.Parse("2d3e6f72-1ae4-4159-865a-77e5abc259f3"),
                    AuthorId = Guid.Parse("aa675ba5-f906-45e1-9d2d-b1293ff82f3e"),
                    Title = "Mythos",
                    Description = "The Greeks myths are amongst the best stories ever told..."
                }

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
