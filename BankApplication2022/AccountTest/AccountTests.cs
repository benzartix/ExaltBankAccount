using Domain.entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Persistance;
using Persistance.Repositories;
using System.Linq.Expressions;

namespace AccountTest
{
    public class AccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Depot()
        {
            //Arrange
            Account account = new Account(1000); 
            //Act
            account.Depot(500);
            
            //Assert
            Assert.AreEqual(1500, account.Solde);
        }

        [Test]
        public void Retrait()
        {
            //Arrange
            Account account = new Account(1000);
            //Act
            account.retrait(500);

            //Assert
            Assert.AreEqual(500, account.Solde);
        }

        [Test]
        public void GetBalance()
        {
            //Arrange
            Account account = new Account(1000);
            //Act
            var t = account.GetBalance(account);
            var y = String.Empty;
            //Assert
            Assert.AreNotEqual(t, y);
        }

       
    }
}