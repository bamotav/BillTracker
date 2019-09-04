using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillTracker.Application.Shared;
using BillTracker.Application.Shared.AccountBank;
using BillTracker.Infraestructure.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BillTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBankController : ControllerBase
    {
        private readonly IAccountBankAppService _accountBankAppService;
        protected readonly ILogger _log = ApplicationLogging.CreateLogger<AccountBankController>();

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