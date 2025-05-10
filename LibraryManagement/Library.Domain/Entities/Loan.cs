namespace LibraryManagement.Library.Domain.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }

        public int Quantity { get; set; }
        public DateTime BorrowDate { get; set; }
        public string BorrowerName { get; set; }

        public Loan(int loanId, int bookId, int quantity, DateTime borrowDate, string borrowerName)
        {
            LoanId = loanId;
            BookId = bookId;
            Quantity = quantity;
            BorrowDate = borrowDate;
            BorrowerName = borrowerName;
        }

        public Loan(int bookId, int quantity, DateTime borrowDate, string borrowerName)
        {
            BookId = bookId;
            Quantity = quantity;
            BorrowDate = borrowDate;
            BorrowerName = borrowerName;
        }
    }
}
