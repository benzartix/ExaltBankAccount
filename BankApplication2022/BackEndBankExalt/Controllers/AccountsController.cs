using Application.AccountServices.CRUD;
using Application.AccountServices.Operations;
using Application.TransactionsServices.CRUD;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net;

namespace BackEndBankExalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AddAccount _addAccount;
        private readonly DepositFund _depositFund;
        private readonly RetraitFunds _retraitFunds;
        private readonly GetByIdAccount _getByIdAccount;
        private readonly DeleteAccount _deleteAccount;
        private readonly ListAllAccount _listAllAccount;
        private readonly UpdateAccount _updateAccount;
        private readonly ListAllTransactionByAccount _listAllTransactionByAccount;


        public AccountsController(
            AddAccount addAccount,
            DepositFund depositFund,
            RetraitFunds retraitFunds,
            GetByIdAccount getByIdAccount,
            DeleteAccount deleteAccount,
            ListAllAccount listAllAccount,
            UpdateAccount updateAccount,
            ListAllTransactionByAccount listAllTransactionByAccount
            )
        {
            _addAccount = addAccount;
            _depositFund = depositFund;
            _retraitFunds = retraitFunds;
            _getByIdAccount = getByIdAccount;
            _deleteAccount = deleteAccount;
            _listAllAccount = listAllAccount;
            _updateAccount = updateAccount;
            _listAllTransactionByAccount = listAllTransactionByAccount;
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            
            try
            {
                _addAccount?.AddAsync(account);
                return StatusCode(StatusCodes.Status200OK,
                "Account Added");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPut]
        public IActionResult UpdateAccount([FromBody] Account account)
        {
          
            try
            {
                _updateAccount?.Update(account);
                return StatusCode(StatusCodes.Status200OK,
                "Account Updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpDelete]

        public IActionResult DeleteAccount([FromBody] Account account)
        {
            try
            {
                _deleteAccount?.Delete(account);
                return StatusCode(StatusCodes.Status200OK,
                "Account deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


     
        [HttpGet]
        public ActionResult<IList<Account>> GetAllAccount()
        {
            try
            {
                var rst = _listAllAccount?.ListAll();
                return StatusCode(StatusCodes.Status200OK,
                rst);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpGet("AccountId")]
        public ActionResult<Account> GetAccountById(Guid Id)
        {

            try
            {
                var rst = _getByIdAccount?.GetByIdAsync(Id);
                if (rst == null) return NotFound();
                return StatusCode(StatusCodes.Status200OK,
                rst);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("Depot/{AccountId}/{solde}")]
        public ActionResult DepotFunds( Guid AccountId, decimal solde)
        {
            try
            {
                var account = _getByIdAccount?.GetByIdAsync(AccountId);
                _depositFund?.Depot(account, solde);
                return StatusCode(StatusCodes.Status200OK,
                "Depot done");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("Retrait/{AccountId}/{solde}")]
        public ActionResult RetraitFunds(Guid AccountId, decimal solde)
        {
            try
            {
                var account = _getByIdAccount?.GetByIdAsync(AccountId);
                _retraitFunds?.Retrait(account, solde);
                return StatusCode(StatusCodes.Status200OK,
                               "retrait done");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("Transaction/{AccountId}")]
        public ActionResult<IList<Transaction>> GetAllTransactionByAccountId()
        {
            try
            {
                var rst = _listAllTransactionByAccount?.ListAll();
                return StatusCode(StatusCodes.Status200OK,
                rst);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("Balance/{AccountId}")]
        public ActionResult<Account> GetBalanceAccount(Guid AccountId)
        {
            try
            {
                var account = _getByIdAccount?.GetByIdAsync(AccountId);
                return StatusCode(StatusCodes.Status200OK,
                account.Solde);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


    }
}
