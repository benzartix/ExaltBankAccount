using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.Operations
{
    public class DepositFund
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public DepositFund(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public void Depot(Account compte, decimal solde)
        {
            if (compte != null)
            {
                try
                {
                    _accountRepository.Depot(compte, solde);
                    Transaction tr = new Transaction();
                    tr.Account = compte;
                    //tr.CreatedBy = compte.User.Fistname + " " + compte.User.Lastname;
                    tr.CreatedDate = DateTime.Now;
                    tr.LastModifiedDate = DateTime.Now;
                    //tr.LastModifiedBy = compte.User.Fistname + " " + compte.User.Lastname;
                    tr.Operation = "Depot";
                    _transactionRepository.AddAsync(tr);
                }
                catch (Exception)
                {
                }
                
                
            }
        }
    }
}
