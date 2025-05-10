using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.Database;
using LibraryManagement.Library.Repository.Interfaces;

namespace LibraryManagement.Library.Repository.DataAccess
{
    class LoanRepository : ILoanRepository
    {
        private readonly LibraryDataSetTableAdapters.LoanTableAdapter _adapter;
        // add a new loan

        public LoanRepository()
        {
            _adapter = new LibraryDataSetTableAdapters.LoanTableAdapter();
            _adapter.Connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.ConnectionString);
        }
        public void AddLoan(Loan loan)
        {
            _adapter.AddLoan(loan.BookId, loan.Quantity, loan.BorrowDate, loan.BorrowerName);
        }
        // delete a loan
        public void DeleteLoan(int id)
        {
            _adapter.DeleteByLoanId(id);
        }
        // update a loan
        public void UpdateLoan(Loan loan)
        {
            _adapter.UpdateByLoanId(loan.BookId, loan.Quantity, loan.BorrowDate, loan.BorrowerName, loan.LoanId);
        }
        // get all loans
        public List<Loan> GetAllLoans()
        {
            var dataTable = _adapter.GetData();
            List<Loan> loans = new List<Loan>();
            foreach (var row in dataTable)
            {
                Loan loan = new Loan(row.LoanId, row.BookId, row.Quantity, row.BorrowDate, row.BorrowerName);
                loans.Add(loan);
            }
            return loans;
        }
        // count loans
        public int CountLoans()
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
