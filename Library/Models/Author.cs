﻿using System;
namespace Library.Models
{
    public class Author
    {
        
        public int AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        public Author()
        {

        }
    }
}

