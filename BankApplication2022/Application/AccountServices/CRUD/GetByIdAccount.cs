using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountServices.CRUD
{
    public class GetByIdAccount
    {
        private readonly IAccountRepository _accountRepository;

        public GetByIdAccount(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetByIdAsync(Guid Id)
        {
            var t = _accountRepository.GetByIdAsync(Id);
            return t;
        }

    }

}
