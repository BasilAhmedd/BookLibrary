﻿using BookLibrary.Data;
using BookLibrary.DTOs;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Repo.BookRepo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddedBook(BookDTO bookDTO)
        {
            var Book = new Book
            {
                Title = bookDTO.Title,
                PublishedYear = bookDTO.PublishedYear,
                Genres = _context.genres.Where(x => bookDTO.GenreIds.Contains(x.Id)).ToList(),
                Authors = _context.authors.Where(x => bookDTO.AuthorIds.Contains(x.Id)).ToList()
            };
            _context.books.Add(Book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var books = _context.books.FirstOrDefault(x => x.Id == id);
            _context.books.Remove(books);
            _context.SaveChanges();
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = _context.books
                .Include(b => b.Genres)
                .Include(b => b.Authors)
                .Select(x=>new BookDTO
            {
                Title=x.Title,
                PublishedYear=x.PublishedYear,  
                Genres = x.Genres.Select(x=>x.Name).ToList(),
                Authors = x.Authors.Select(x=>x.Name).ToList(),
            }).ToList();

            return books;
        }

        public BookDTO GetById(int id)
        {
            var Book = _context.books
                .Include(x=>x.Genres)
                .Include(x=>x.Authors).FirstOrDefault(s=>s.Id == id);

            return new 
            BookDTO { 
             Title=Book.Title, PublishedYear=Book.PublishedYear,
             Genres = Book.Genres.Select(b=>b.Name).ToList(),
             Authors = Book.Authors.Select(b=>b.Name).ToList(),
            
            };
        }

        public void UpdateBook(BookDTO bookDTO, int id)
        {
            var book = _context.books
                .Include(x=>x.Genres)
                .Include(s=>s.Authors)
                .FirstOrDefault(x=>x.Id==id);
            book.Title = bookDTO.Title;
            book.PublishedYear = bookDTO.PublishedYear;
            book.Authors = _context.authors.Where(x => bookDTO.AuthorIds.Contains(x.Id)).ToList();
            book.Genres = _context.genres.Where(x => bookDTO.GenreIds.Contains(x.Id)).ToList();
            _context.Update(book);
            _context.SaveChanges();
        }
    }
}