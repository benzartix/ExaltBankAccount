using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Account : BaseEntity
    {

        #region Properties
        [MaxLength(50)]
        public string AccountId { get; set; }
        public decimal? Solde { get; set; }
        public User User { get; set; }

        #endregion

        public Account()
        {
        }

        public Account(decimal solde)
        {
            Solde = solde;
        }

        public void Depot(decimal ammount)
        {
            Solde += ammount;
        }

        public void retrait(decimal ammount)
        {
            Solde -= ammount;
        }

        public string GetBalance(Account account)
        {
            return account.Solde.ToString();

        }
    }
}
