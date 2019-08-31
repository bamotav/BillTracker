using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillTracker.Application.Shared;
using BillTracker.Application.Shared.AccountBank;
using Microsoft.AspNetCore.Mvc;


namespace BillTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBankController : ControllerBase
    {
        private readonly IAccountBankAppService _accountBankAppService;
        public AccountBankController(IAccountBankAppService accountBankAppService)
        {
            _accountBankAppService = accountBankAppService;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<AccountBankDto>>> Get()
        {
            return await _accountBankAppService.GetAll();
        }

      
    }
}