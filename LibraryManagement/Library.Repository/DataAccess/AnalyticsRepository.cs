using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.Database;
using LibraryManagement.Library.Repository.Interfaces;

namespace LibraryManagement.Library.Repository.DataAccess
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly LibraryDataSetTableAdapters.AnalyticsTableAdapter _adapter;

        public AnalyticsRepository()
        {
            _adapter = new LibraryDataSetTableAdapters.AnalyticsTableAdapter();
            _adapter.Connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.ConnectionString);
        }

        public void AddLoan(Loan loan)
        {
            _adapter.AddAnalytics(loan.BookId, loan.Quantity, loan.BorrowDate, loan.BorrowerName);
        }
        public void DeleteLoan(int id)
        {
            _adapter.DeleteByAnalyticsId(id);
        }
        public void UpdateLoan(Loan loan)
        {
            _adapter.UpdateByAnalyticsId(loan.BookId, loan.Quantity, loan.BorrowDate, loan.BorrowerName, loan.LoanId);
        }
        public List<Loan> GetAllLoans()
        {
            var dataTable = _adapter.GetData();
            List<Loan> loans = new List<Loan>();
            foreach (var row in dataTable)
            {
                Loan loan = new Loan(row.Id, row.BookId, row.Quantity, row.BorrowDate, row.BorrowerName);
                loans.Add(loan);
            }
            return loans;
        }
        public int CountLoans()
        {
            var dataTable = _adapter.GetData();
            return dataTable.Count;
        }
    }
}
