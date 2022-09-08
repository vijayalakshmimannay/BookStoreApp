using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IBookBL
    {
        public bool AddBook(BookModel bookModel);
        public BookModel GetBookById(int BookId);
        public List<GetAllBookModel> GetAllBooks();
        public bool UpdateBook(BookModel bookModel);
        public string DeleteBook(int BookId);
    }
}
