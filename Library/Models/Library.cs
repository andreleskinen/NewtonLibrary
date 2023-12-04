﻿using System;
namespace Library.Models
{
    public class Library
    {
        public Guid Id { get; set; }

        public ICollection<Book> books { get; set; } = new List<Book>();

        public ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();
    }
}
