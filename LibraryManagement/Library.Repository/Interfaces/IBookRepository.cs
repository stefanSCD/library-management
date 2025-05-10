using LibraryManagement.Library.Domain.Entities;

namespace LibraryManagement.Library.Repository.Interfaces
{
    public interface IBookRepository
    {
        // add a new book
        void AddBook(Book book);

        // delete a book
        void DeleteBook(int id);

        // update a book
        void UpdateBook(Book book);

        // get all books
        List<Book> GetAllBooks();

        // search books with a specific text
        List<Book> SearchBooks(string text);

        // count books
        int CountBooks();
    }
}
