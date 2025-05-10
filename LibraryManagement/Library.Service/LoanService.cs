using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.Interfaces;

namespace LibraryManagement.Library.Service
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;
        public LoanService(ILoanRepository loanRepository)
        {
            this._loanRepository = loanRepository;
        }
        // add a new loan
        public void AddLoan(int bookId, int quantity, DateTime borrowDate, string borrowerName)
        {
            Loan loan = new Loan(bookId, quantity, borrowDate, borrowerName);
            _loanRepository.AddLoan(loan);
        }
        // delete a loan
        public void DeleteLoan(int id)
        {
            _loanRepository.DeleteLoan(id);
        }
        // update a loan
        public void UpdateLoan(int id, int bookId, int quantity, DateTime borrowDate, string borrowerName)
        {
            Loan loan = new Loan(id, bookId, quantity, borrowDate, borrowerName);
            _loanRepository.UpdateLoan(loan);
        }
        // return all loans from repository
        public List<Loan> GetAllLoans()
        {
            return _loanRepository.GetAllLoans();
        }
        // count loans
        public int CountLoans()
        {
            return _loanRepository.CountLoans();
        }

    }
}
