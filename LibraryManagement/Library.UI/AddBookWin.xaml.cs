using System.Windows;
using LibraryManagement.Library.Service;

namespace LibraryManagement.Library.UI
{
    public partial class AddBookWin : Window
    {
        private BookService bookService;
        public AddBookWin(BookService bookSrv)
        {
            InitializeComponent();
            this.bookService = bookSrv;
        }

        private void AddBookWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Please enter an author.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter a quantity.");
                return;
            }

            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            int quantity;
            if (int.TryParse(txtQuantity.Text, out quantity))
            {
                
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity (1,2,3...).");
                return;
            }
            bookService.AddBook(title, author, quantity);
            this.txtQuantity.Text = "";
            this.txtTitle.Text = "";
            this.txtAuthor.Text = "";
            MessageBox.Show("Succes!");
        }
    }
}
