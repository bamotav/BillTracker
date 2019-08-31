using BillTracker.Application.Shared;
using BillTracker.Application.Shared.AccountBank;
using BillTracker.Application.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillTracker.Domain;

namespace BillTracker.Application
{
    [InjectionTransientLifetime]
    public class AccountBankService : IAccountBankAppService
    {
        public Task<List<AccountBankDto>> GetAll()
        {
            return Task.FromResult(new List<AccountBankDto>(){
                new AccountBankDto {
                    NameAccount = "Account Bhd",
                    NumberAccount = "234123412341324",
                    Bank = Bank.BhdLeon
                },
                new AccountBankDto {
                    NameAccount = "Account Popular",
                    NumberAccount = "1234123412341123",
                    Bank = Bank.Popular
                }
            });
        }
    }
}
