using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccountRepository : IAsyncRepository<Account>
    {
        void Depot(Account account, decimal amount);
        void Retrait(Account account, decimal amount);
    }
}
