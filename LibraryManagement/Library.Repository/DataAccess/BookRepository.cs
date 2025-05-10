using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.Database;
using LibraryManagement.Library.Repository.Interfaces;

namespace LibraryManagement.Library.Repository.DataAccess
{
    class BookRepository : IBookRepository
    {
        private LibraryDataSetTableAdapters.BookTableAdapter _adapter;

        public BookRepository()
        {
            _adapter = new LibraryDataSetTableAdapters.BookTableAdapter();
            _adapter.Connection= new System.Data.SqlClient.SqlConnection(DatabaseHelper.ConnectionString);
        }

        public void AddBook(Book book)
        {
            _adapter.AddBook(book.Title, book.Author, book.Quantity);
            
        }

        public void DeleteBook(int id)
        {
            _adapter.DeleteById(id);
        }

        public void UpdateBook(Book book)
        {
            _adapter.UpdateById(book.Title, book.Author, book.Quantity, book.Id);
        }

        public List<Book> GetAllBooks()
        {
            var dataTable = _adapter.GetData();
            List<Book> books = new List<Book>();
            foreach (var row in dataTable)
            {
                Book book = new Book(row.Id, row.Title, row.Author, row.Quantity);
                books.Add(book);
            }
            return books;
        }
        public List<Book> SearchBooks(string text)
        {
            var dataTable = _adapter.GetData();
            List<Book> books = new List<Book>();
            foreach (var row in dataTable)
            {
                if (row.Title.ToLower().Contains(text) || row.Author.ToLower().Contains(text))
                {
                    Book book = new Book(row.Id, row.Title, row.Author, row.Quantity);
                    books.Add(book);
                }
            }
            return books;
        }

        public int CountBooks()
        {
            var dataTable = _adapter.GetData();
            int count = 0;
            foreach (var row in dataTable)
            {
                count += row.Quantity;
            }
            return count;
        }
    }
}
