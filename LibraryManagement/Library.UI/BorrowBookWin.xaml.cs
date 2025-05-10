using System.Data.SqlClient;
using System.IO;
using System.Windows;
using LibraryManagement.Library.Repository.DataAccess;
using LibraryManagement.Library.Repository.DataAccess.LibraryDataSetTableAdapters;
using LibraryManagement.Library.Repository.Database;
using LibraryManagement.Library.Service;

namespace LibraryManagement.Library.UI
{

    public partial class BorrowBookWin : Window
    {
        private BookService bookService;
        private LoanService loanService;
        private AnalyticsService analyticsService;
        private AnalyticsRepository analyticsRepo;
        public BorrowBookWin(BookService bkServ, LoanService lnServ)
        {
            InitializeComponent();
            analyticsRepo = new AnalyticsRepository();
            analyticsService = new AnalyticsService(analyticsRepo);
            this.loanService = lnServ;
            this.bookService = bkServ;
            loadData();
        }


        private void BorrowBookWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadData()
        {
            LibraryDataSet.AvailableBooksDataTable availableBooks = new LibraryDataSet.AvailableBooksDataTable();
            AvailableBooksTableAdapter adapter = new AvailableBooksTableAdapter();
            adapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
            adapter.Fill(availableBooks);
            dgBooks.ItemsSource = availableBooks.DefaultView;
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            int bookId, quantity;
            if (int.TryParse(this.txtBookId.Text, out bookId))
            {

            }
            else
            {
                MessageBox.Show("Please enter a valid book ID.");
                return;
            }
            if (int.TryParse(this.txtQuantity.Text, out quantity))
            {

            }
            else
            {
                MessageBox.Show("Please enter a valid book quantity.");
                return;
            }
            if (string.IsNullOrEmpty(this.txtBorrowerName.Text))
            {
                MessageBox.Show("Please enter a valid borrower name.");
                return;
            }
            if(quantity < 1)
            {
                MessageBox.Show("Please enter a valid quantity (>=1).");
                return;
            }
            LibraryDataSet.AvailableBooksDataTable availableBooks = new LibraryDataSet.AvailableBooksDataTable();
            AvailableBooksTableAdapter adapter = new AvailableBooksTableAdapter();
            adapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
            int availability = Convert.ToInt32(adapter.FillByAvailability(bookId));
            if(availability - quantity < 0)
            {
                MessageBox.Show("Invalid quantity!");
                this.txtBorrowerName.Clear();
                this.txtBookId.Clear();
                this.txtQuantity.Clear();
                return;
            }
            string borrowerName = this.txtBorrowerName.Text;
            DateTime borrowDate = DateTime.Now;
            loanService.AddLoan(bookId, quantity, borrowDate, borrowerName);
            analyticsService.AddLoan(bookId, quantity, borrowDate, borrowerName);
            MessageBox.Show("Book borrowed successfully.");
            this.txtBorrowerName.Clear();
            this.txtBookId.Clear();
            this.txtQuantity.Clear();
            loadData();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSearch.Text))
            {
                loadData();
                return;
            }
            string text = this.txtSearch.Text.ToLower();
            LibraryDataSet.AvailableBooksDataTable availableBooks = new LibraryDataSet.AvailableBooksDataTable();
            AvailableBooksTableAdapter adapter = new AvailableBooksTableAdapter();
            adapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
            adapter.FillByPattern(availableBooks, text);
            dgBooks.ItemsSource = availableBooks.DefaultView;
        }
    }
}
