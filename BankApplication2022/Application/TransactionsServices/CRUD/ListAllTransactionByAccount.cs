using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TransactionsServices.CRUD
{
    public class ListAllTransactionByAccount
    {
        private readonly ITransactionRepository _transactionRepository;

        public ListAllTransactionByAccount(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IList<Transaction> ListAll()
        {
            var t = _transactionRepository.ListAllAsync();
            return t;
        }
    }
}
