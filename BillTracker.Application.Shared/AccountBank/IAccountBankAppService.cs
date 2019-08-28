using System;
using System.Threading.Tasks;

namespace BillTracker.Application.Shared
{
    public interface IAccountBankAppService
    {
        //For testing dependecy injection
        Task<int> Get();
    }
}
