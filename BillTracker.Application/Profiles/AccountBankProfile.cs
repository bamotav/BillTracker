using AutoMapper;
using BillTracker.Application.Shared.AccountBank;
using BillTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillTracker.Application
{
   public class AccountBankProfile : Profile
    {
        public AccountBankProfile()
        {
            CreateMap<AccountBank, AccountBankDto>();
        }
    }
}
