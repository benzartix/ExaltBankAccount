using Domain.entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TransactionsServices.CRUD
{
    public class AddTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public AddTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddAsync(Transaction entity)
        {
            _transactionRepository.AddAsync(entity);
        }

    }
}
