using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.CRUD
{
    public class UpdateAccount
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccount(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Update(Account account)
        {
            _accountRepository.UpdateAsync(account);
        }

    }
}
