using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.Operations
{
    public class RetraitFunds
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public RetraitFunds(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public void Retrait(Account compte, decimal solde)
        {
            if (compte != null)
            {
                try
                {
                    _accountRepository.Retrait(compte, solde);
                    Transaction tr = new Transaction();
                    tr.Account = compte;
                    //tr.CreatedBy = compte.User.Fistname + " " + compte.User.Lastname;
                    tr.CreatedDate = DateTime.Now;
                    tr.LastModifiedDate = DateTime.Now;
                    //tr.LastModifiedBy = compte.User.Fistname + " " + compte.User.Lastname;
                    tr.Operation = "Retrait";
                    _transactionRepository.AddAsync(tr);
                }
                catch (Exception)
                {
                };
            }
        }
    }
}
