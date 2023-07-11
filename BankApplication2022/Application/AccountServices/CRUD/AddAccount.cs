using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.CRUD
{
    public class AddAccount
    {
        private readonly IAccountRepository _accountRepository;

        public AddAccount(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AddAsync(Account entity)
        {
            _accountRepository.AddAsync(entity);
        }

    }
}
