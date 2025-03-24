﻿// <auto-generated />
using System;
using BookLibraryManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookLibraryManager.Migrations
{
    [DbContext(typeof(BookManagerContext))]
    [Migration("20250324220722_AppInit")]
    partial class AppInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookLibraryManager.DomainModels.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.AuthorsBooks", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorsBooks");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.AuthorsPublishers", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorId", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("AuthorsPublishers");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BookBlob")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BookCoverImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("integer");

                    b.Property<Instant>("PublishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Publisher", b =>
                {
                    b.Property<Guid>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PublisherAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Rating", b =>
                {
                    b.Property<Guid>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("BookReview")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("RatingScore")
                        .HasColumnType("double precision");

                    b.HasKey("RatingId");

                    b.HasIndex("BookId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.AuthorsBooks", b =>
                {
                    b.HasOne("BookLibraryManager.DomainModels.Author", "Author")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibraryManager.DomainModels.Book", "Book")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.AuthorsPublishers", b =>
                {
                    b.HasOne("BookLibraryManager.DomainModels.Author", "Author")
                        .WithMany("AuthorsPublishers")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibraryManager.DomainModels.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Book", b =>
                {
                    b.HasOne("BookLibraryManager.DomainModels.Publisher", "Publisher")
                        .WithMany("BooksPublished")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Rating", b =>
                {
                    b.HasOne("BookLibraryManager.DomainModels.Book", null)
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Author", b =>
                {
                    b.Navigation("AuthorsBooks");

                    b.Navigation("AuthorsPublishers");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Book", b =>
                {
                    b.Navigation("AuthorsBooks");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("BookLibraryManager.DomainModels.Publisher", b =>
                {
                    b.Navigation("BooksPublished");
                });
#pragma warning restore 612, 618
        }
    }
}
