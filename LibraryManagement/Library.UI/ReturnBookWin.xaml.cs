using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.DataAccess;
using LibraryManagement.Library.Repository.DataAccess.LibraryDataSetTableAdapters;
using LibraryManagement.Library.Repository.Database;
using LibraryManagement.Library.Service;

namespace LibraryManagement.Library.UI
{
    public partial class ReturnBookWin : Window
    {

        private LoanService loanService;
        public ReturnBookWin(LoanService loanServ)
        {
            InitializeComponent();
            this.loanService = loanServ;
            DataContext = this;
            loadData();
        }

        private void loadData()
        {
            LibraryDataSet.ActiveLoansDataTable activeLoans = new LibraryDataSet.ActiveLoansDataTable();
            ActiveLoanssTableAdapter activeLoanssTableAdapter = new ActiveLoanssTableAdapter();
            activeLoanssTableAdapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
            activeLoanssTableAdapter.Fill(activeLoans);
            dgLoans.ItemsSource = activeLoans.DefaultView;
        }

        private void ReturnBookWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag != null)
            {
                int loanId = Convert.ToInt32(button.Tag);
                loanService.DeleteLoan(loanId);
                loadData();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtSearch.Text))
            {
                loadData();
                return;
            }
            string text = this.txtSearch.Text.ToLower();
            LibraryDataSet.ActiveLoansDataTable activeLoans = new LibraryDataSet.ActiveLoansDataTable();
            ActiveLoanssTableAdapter activeLoanssTableAdapter = new ActiveLoanssTableAdapter();
            activeLoanssTableAdapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
            activeLoanssTableAdapter.FillBySearch(activeLoans, text);
            dgLoans.ItemsSource = activeLoans.DefaultView;
        }
    }
}
