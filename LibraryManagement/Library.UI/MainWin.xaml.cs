using LibraryManagement.Library.UI;
using System.Windows;
using LibraryManagement.Library.Service;
using LibraryManagement.Library.Repository;
using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.DataAccess;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LibraryManagement
{
    
    public partial class MainWin : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        private BookRepository bookRepository;
        private BookService bookService;
        private LoanRepository loanRepository;
        private LoanService loanService;
        public MainWin()
        {
            InitializeComponent();
            bookRepository = new BookRepository();
            loanRepository = new LoanRepository();
            bookService = new BookService(bookRepository);
            loanService = new LoanService(new LoanRepository());
            Books = new ObservableCollection<Book>();
            DataContext = this;
            LoadWindow();
        }

        private void LoadWindow()
        {
            int booksCount = bookService.CountBooks();
            int loansCount = loanService.CountLoans();
            this.txtTotalBooks.Text = booksCount.ToString();
            this.txtBooksBorrowed.Text = loansCount.ToString();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnViewAllBooks_Click(object sender, RoutedEventArgs e)
        {
            ViewAllBooksWin viewAllBooksWin = new ViewAllBooksWin(bookService);
            viewAllBooksWin.ShowDialog();
        }

        private void btnQuickSearch_Click(object sender, RoutedEventArgs e)
        {
            string text = this.txtQuickSearch.Text.ToLower();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a title or author to search.");
                Books.Clear();
                return;
            }

            var books = bookService.SearchBooks(text);
            if (books.Count == 0)
            {
                MessageBox.Show("No books found.");
                Books.Clear();
                return;
            }
            else
            {
                // Golește colecția existentă
                Books.Clear();

                // Adaugă rezultatele căutării
                foreach (var book in books)
                {
                    Books.Add(book);
                }

                // Setează sursa pentru DataGrid
                dgQuickSearchResults.ItemsSource = Books;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void menuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBorrowBook_Click(object sender, RoutedEventArgs e)
        {
            BorrowBookWin borrowBookWin = new BorrowBookWin(bookService, loanService);
            borrowBookWin.ShowDialog();
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            ReturnBookWin returnBookWin = new ReturnBookWin(loanService);
            returnBookWin.ShowDialog();
        }

        private void btnManageBooks_Click(object sender, RoutedEventArgs e)
        {
            ManageBooksWin manageBooksWin = new ManageBooksWin(bookService);
            manageBooksWin.ShowDialog();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            dgQuickSearchResults.ItemsSource = null;
            LoadWindow();
        }

        private void btnAnalytics_Click(object sender, RoutedEventArgs e)
        {
            AnalyticsWin analyticsWin = new AnalyticsWin();
            analyticsWin.ShowDialog();
        }
    }
}
