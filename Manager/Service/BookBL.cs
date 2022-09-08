using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public bool AddBook(BookModel bookModel)
        {
            try
            {
                return this.bookRL.AddBook(bookModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<GetAllBookModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BookModel GetBookById(int BookId)
        {
            try
            {
                return this.bookRL.GetBookById(BookId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateBook(BookModel bookModel)
        {
            try
            {
                return this.bookRL.UpdateBook(bookModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string DeleteBook(int BookId)
        {
            try
            {
                return this.bookRL.DeleteBook(BookId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
