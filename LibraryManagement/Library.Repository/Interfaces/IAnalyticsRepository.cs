using LibraryManagement.Library.Domain.Entities;

namespace LibraryManagement.Library.Repository.Interfaces
{
    public interface IAnalyticsRepository
    {
        // add a new loan
        void AddLoan(Loan loan);

        // delete a loan
        void DeleteLoan(int id);

        // update a loan
        void UpdateLoan(Loan loan);
        // get all loans
        List<Loan> GetAllLoans();
        // count loans
        int CountLoans();
    }
}
