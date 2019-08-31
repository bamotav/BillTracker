using BillTracker.Domain;

namespace BillTracker.Application.Shared.AccountBank
{
    public class AccountBankDto
    {
        public string NameAccount { get; set; }
        public string NumberAccount { get; set; }
        public Bank Bank { get; set; }
    }
}