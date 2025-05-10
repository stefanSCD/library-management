using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;


namespace LibraryManagement.Library.UI
{
    public partial class ManageBooksWin : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Book> _books;
        private BookService bookService;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        public ManageBooksWin(BookService bookSrv)
        {
            InitializeComponent();
            DataContext = this;
            Books = new ObservableCollection<Book>();
            this.bookService = bookSrv;
            loadData();
        }

        private void ManageBooksWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadData()
        {
            Books.Clear();
            var books = bookService.GetAllBooks();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        private void btnAddNewBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookWin addBookWin = new AddBookWin(bookService);
            addBookWin.ShowDialog();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtSearch.Text))
            {
                loadData();
                return;
            }
            Books.Clear();
            string text = this.txtSearch.Text.ToLower();
            var books = bookService.SearchBooks(text);
            foreach (var book in books)
            {
                if (!Books.Contains(book))
                {
                    Books.Add(book);
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ManageBooksWindow_Activated(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgBooks_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgBooks.SelectedItem != null)
            {
                Book selectedBook = dgBooks.SelectedItem as Book;

                if (selectedBook != null)
                {
                    txtEditId.Text = selectedBook.Id.ToString();
                    txtEditTitle.Text = selectedBook.Title;
                    txtEditAuthor.Text = selectedBook.Author;
                    txtEditQuantity.Text = selectedBook.Quantity.ToString();

                    txtDeleteId.Text = selectedBook.Id.ToString();
                }
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtEditTitle.Text))
            {
                MessageBox.Show("Please enter a title.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtEditAuthor.Text))
            {
                MessageBox.Show("Please enter an author.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtEditQuantity.Text))
            {
                MessageBox.Show("Please enter a quantity.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtEditId.Text))
            {
                MessageBox.Show("Please enter an id.");
                return;
            }
            string title = this.txtEditTitle.Text;
            string author = this.txtEditAuthor.Text;
            int quantity, id;
            if (int.TryParse(this.txtEditQuantity.Text, out quantity))
            {
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity (1,2,3...).");
                return;
            }
            if (int.TryParse(this.txtEditId.Text, out id))
            {
            }
            else
            {
                MessageBox.Show("Please enter a valid id!");
                return;
            }
            if(quantity < 1)
            {
                MessageBox.Show("Please enter a valid quantity (1,2,3...).");
                return;
            }
            bookService.UpdateBook(title, author, quantity, id);
            MessageBox.Show("Succes!");
            this.txtEditQuantity.Text = "";
            this.txtEditTitle.Text = "";
            this.txtEditAuthor.Text = "";
            this.txtEditId.Text = "";
            this.txtDeleteId.Text = "";
        }

        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtDeleteId.Text))
            {
                MessageBox.Show("Please enter an id.");
                return;
            }
            int id;
            if (int.TryParse(this.txtDeleteId.Text, out id))
            {
            }
            else
            {
                MessageBox.Show("Please enter a valid id!");
                return;
            }
            bookService.DeleteBook(id);
            MessageBox.Show("Succes!");
            this.txtEditQuantity.Text = "";
            this.txtEditTitle.Text = "";
            this.txtEditAuthor.Text = "";
            this.txtEditId.Text = "";
            this.txtDeleteId.Text = "";

        }
    }
}
