﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231208111219_Library14")]
    partial class Library14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorId", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Borrowed")
                        .HasColumnType("bit");

                    b.Property<int?>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.Borrower", b =>
                {
                    b.Property<int>("BorrowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowerId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LibraryCardNumber")
                        .HasColumnType("int");

                    b.HasKey("BorrowerId");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Library.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Borrower", null)
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BorrowerId");
                });

            modelBuilder.Entity("Library.Models.Borrower", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
