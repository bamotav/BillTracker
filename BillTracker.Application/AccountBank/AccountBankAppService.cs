using BillTracker.Application.Shared;
using BillTracker.Application.Shared.Attributes;
using System;
using System.Threading.Tasks;

namespace BillTracker.Application
{
    [InjectionSingleton]
    public class AccountBankAppService : IAccountBankAppService
    {
        public async Task<int> Get()
        {
            return await Task.FromResult(1);
        }
    }
}
