using Domain.entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Persistance.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region CRUD
        public void AddAsync(Account entity)
        {

            _dbContext.Account.AddAsync(entity);
            _dbContext.SaveChangesAsync();

        }

        public void DeleteAsync(Account entity)
        {

            _dbContext.Account.Remove(entity);
            _dbContext.SaveChangesAsync();

        }

        public Account GetByIdAsync(Guid Id)
        {

            var account = _dbContext.Account.Find(Id);
            _dbContext.SaveChangesAsync();
            return account;

        }

        public void UpdateAsync(Account account)
        {

            _dbContext.Account.Update(account);
            _dbContext.SaveChangesAsync();

        }

        public IList<Account> ListAllAsync()
        {

            var accounts = _dbContext.Account.ToList();
            return accounts;

        }


        #endregion

        #region Operations

        public void Retrait(Account account, decimal amount)
        {

            account.retrait(amount);
            _dbContext.SaveChanges();

        }

        public void Depot(Account account, decimal amount)
        {
            account.Depot(amount);
            _dbContext.SaveChanges();
        }



        #endregion



    }
}
