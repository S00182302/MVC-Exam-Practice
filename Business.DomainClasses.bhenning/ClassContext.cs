using Business.DomainClasses.bhenning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.bhenning
{
    public class ClassContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ClassContext() : base("BankConnection")
        {

        }

        public static ClassContext Create()
        {
            return new ClassContext();
        }

    }

    
}
