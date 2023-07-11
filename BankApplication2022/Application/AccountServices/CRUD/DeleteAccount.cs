using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.CRUD
{
    public class DeleteAccount
    {
        private readonly IAccountRepository _accountRepository;

        public DeleteAccount(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Delete(Account entity)
        {
            _accountRepository.DeleteAsync(entity);
        }

    }
}
