﻿namespace Entites.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string? Biography { get; set; }

        public IEnumerable<Book>? Books { get; set; }
    }
}
