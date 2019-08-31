using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillTracker.Application.Shared.AccountBank;

namespace BillTracker.Application.Shared
{
    public interface IAccountBankAppService
    {
        //For testing dependecy injection
        Task<List<AccountBankDto>> GetAll();
    }
}
