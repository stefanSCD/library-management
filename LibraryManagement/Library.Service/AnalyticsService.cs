using LibraryManagement.Library.Domain.Entities;
using LibraryManagement.Library.Repository.Interfaces;

namespace LibraryManagement.Library.Service
{
    public class AnalyticsService
    {
        private readonly IAnalyticsRepository analyticsRepository;
        public AnalyticsService(IAnalyticsRepository AnalyticsRepository)
        {
            this.analyticsRepository = AnalyticsRepository;
        }
        // add a new loan
        public void AddLoan(int bookId, int quantity, DateTime borrowDate, string borrowerName)
        {
            Loan loan = new Loan(bookId, quantity, borrowDate, borrowerName);
            analyticsRepository.AddLoan(loan);
        }
        // delete a loan
        public void DeleteLoan(int id)
        {
            analyticsRepository.DeleteLoan(id);
        }
        // update a loan
        public void UpdateLoan(int id, int bookId, int quantity, DateTime borrowDate, string borrowerName)
        {
            Loan loan = new Loan(id, bookId, quantity, borrowDate, borrowerName);
            analyticsRepository.UpdateLoan(loan);
        }
        // return all loans from repository
        public List<Loan> GetAllLoans()
        {
            return analyticsRepository.GetAllLoans();
        }
        // count loans
        public int CountLoans()
        {
            return analyticsRepository.CountLoans();
        }

    }
}
