using BillTracker.Application.Shared;
using System;
using System.Threading.Tasks;

namespace BillTracker.Application
{
    public class AccountBankAppService : IAccountBankAppService
    {
        public async Task<int> Get()
        {
            return await Task.FromResult(1);
        }
    }
}
