using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.Interfaces;

namespace LibraryManagement.Library.Service
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        // add a new book
        public void AddBook(string title, string author, int quantity)
        {
            Book book = new Book(title, author, quantity);
            _bookRepository.AddBook(book);
        }

        // delete a book
        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        // update a book
        public void UpdateBook(string title, string author, int quantity,int id)
        {
            Book book = new Book(id, title, author, quantity);
            _bookRepository.UpdateBook(book);
        }

        // return all books from repository
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        // search books with a specific text
        public List<Book> SearchBooks(string text)
        {
            return _bookRepository.SearchBooks(text);
        }

        // count books
        public int CountBooks()
        {
            return _bookRepository.CountBooks();
        }
    }
}
