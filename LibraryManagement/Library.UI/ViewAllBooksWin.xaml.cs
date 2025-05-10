using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.DataAccess.LibraryDataSetTableAdapters;
using LibraryManagement.Library.Repository.Database;
using LibraryManagement.Library.Service;
using System.Linq;
using LibraryManagement.Library.Repository.DataAccess;

namespace LibraryManagement.Library.UI
{
    public partial class ViewAllBooksWin : Window
    {
        private LibraryDataSet.ViewBooksDataTable _currentData;

        public ViewAllBooksWin(BookService bookSrv)
        {
            InitializeComponent();
            LoadDataInGrid();
            LoadDataInTextBoxes();
        }

        private void LoadDataInTextBoxes()
        {
            LibraryDataSet.ViewBooksDataTable viewBooksDT = new LibraryDataSet.ViewBooksDataTable();
            ViewBooksTableAdapter adapter = new ViewBooksTableAdapter();
            adapter.Connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.ConnectionString);
            adapter.Fill(viewBooksDT);

            int totalQuantity = 0;
            int totalDisponibile = 0;

            foreach (LibraryDataSet.ViewBooksRow row in viewBooksDT.Rows)
            {
                totalQuantity += row.Quantity;
                totalDisponibile += row.Disponibile;
            }

            int borrowed = totalQuantity - totalDisponibile;
            this.txtTotalBooks.Text = viewBooksDT.Rows.Count.ToString();
            this.txtAvailableBooks.Text = totalDisponibile.ToString();
            this.txtBorrowedBooks.Text = borrowed.ToString();
        }

        private void LoadDataInGrid()
        {
            LibraryDataSet.ViewBooksDataTable viewBooksDT = new LibraryDataSet.ViewBooksDataTable();
            ViewBooksTableAdapter adapter = new ViewBooksTableAdapter();
            adapter.Connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.ConnectionString);
            adapter.Fill(viewBooksDT);

            _currentData = viewBooksDT;
            dgBooks.ItemsSource = viewBooksDT;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSearch.Text))
            {
                LoadDataInGrid();
                return;
            }

            string searchText = this.txtSearch.Text.ToLower();

            var filteredRows = _currentData.AsEnumerable()
                .Where(row => row.Title.ToLower().Contains(searchText) ||
                              row.Author.ToLower().Contains(searchText))
                .ToList();

            LibraryDataSet.ViewBooksDataTable filteredTable = new LibraryDataSet.ViewBooksDataTable();

            foreach (var row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }

            dgBooks.ItemsSource = filteredTable;
        }
    }
}