using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.CRUD
{
    public class ListAllAccount
    {
        private readonly IAccountRepository _accountRepository;

        public ListAllAccount(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IList<Account> ListAll()
        {
            var t =  _accountRepository.ListAllAsync();
            return t; 
        }
    }
}
