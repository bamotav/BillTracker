using BillTracker.Application.Shared;
using BillTracker.Application.Shared.Attributes;
using System;
using System.Threading.Tasks;

namespace BillTracker.Application
{
    [InjectionTransientLifetime]
    public class AccountBankService : IAccountBankAppService
    {
        public async Task<int> Get()
        {
            return await Task.FromResult(1);
        }
    }
}
