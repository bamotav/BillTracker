using BillTracker.Application.Shared;
using BillTracker.Application.Shared.AccountBank;
using BillTracker.Application.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillTracker.Domain;
using BillTracker.Infraestructure;
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BillTracker.Infraestructure.Interfaces;

namespace BillTracker.Application
{
    [InjectionTransientLifetime]
    public class AccountBankService : IAccountBankAppService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountBankService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<AccountBankDto>> GetAll()
        {
            var accountBanks = await _unitOfWork.Repository<AccountBank>().Query().ToListAsync();

            var result = _mapper.Map<List<AccountBankDto>>(accountBanks);

            return result;
        }
    }
}
