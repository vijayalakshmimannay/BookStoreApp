using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace BookStoreApp.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpPost("AddBook")]
        public ActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var book = this.bookBL.AddBook(bookModel);
                if (book != null)
                {
                    return this.Ok(new { success = true, message = "Book added successfully", data = book });
                }
                return this.BadRequest(new { success = false, message = "Failed to add book", data = book });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("UpdateBook")]
        public ActionResult UpdateBook(BookModel bookModel)
        {
            try
            {
                var book = this.bookBL.UpdateBook(bookModel);
                if (book != null)
                {
                    return this.Ok(new { success = true, message = "Book updated successfully", data = book });
                }
                return this.BadRequest(new { success = false, message = "Failed to update a book", data = book });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteBook")]
        public ActionResult DeleteBook(int BookId)
        {
            try
            {
                var book = this.bookBL.DeleteBook(BookId);
                if (book != null)
                {
                    return this.Ok(new { success = true, message = "Book is deleted", data = book });
                }
                return this.BadRequest(new { success = false, message = "Failed to delete a book", data = book });
            }
            catch
            {

                throw;
            }
        }

    }

}
