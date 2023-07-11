using Domain.entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Persistance.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region CRUD
        public void AddAsync(Transaction entity)
        {

            _dbContext.Transaction.AddAsync(entity);
            _dbContext.SaveChangesAsync();

        }

        public void DeleteAsync(Transaction entity)
        {

            _dbContext.Transaction.Remove(entity);
            _dbContext.SaveChangesAsync();

        }

        public Transaction GetByIdAsync(Guid Id)
        {

            var entity = _dbContext.Transaction.Find(Id);
            _dbContext.SaveChangesAsync();
            return entity;

        }

        public void UpdateAsync(Transaction entity)
        {

            _dbContext.Transaction.Update(entity);
            _dbContext.SaveChangesAsync();

        }

        public IList<Transaction> ListAllAsync()
        {

            var entitys = _dbContext.Transaction.ToList();
            return entitys;

        }


        #endregion

        



    }
}
