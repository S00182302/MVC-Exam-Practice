namespace Business.DomainClasses.bhenning.Migrations.DataContext
{
    using Business.DomainClasses.bhenning.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Business.DomainClasses.bhenning.ClassContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DataConnection";
        }

        protected override void Seed(Business.DomainClasses.bhenning.ClassContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            SeedCustomers(context);
            SeedAccountTypes(context);
            SeedAccounts(context);
            SeedTransactions(context);
        }

        private void SeedTransactions(ClassContext context)
        {
            if (context.Transactions.Select(c => c).Count() == 0)
            {
                context.Transactions.AddOrUpdate(c => c.ID,
                        new Models.Transaction
                        {
                            ID = 1,
                            TransactionType = Models.TransactionType.Lodgement,
                            Amount = 300,
                            TransactionDate = new DateTime(2002, 01, 18),
                            AccountID = 1
                        },
                        new Models.Transaction
                        {
                            ID = 2,
                            TransactionType = Models.TransactionType.WithDrawal,
                            Amount = 500,
                            TransactionDate = new DateTime(2002, 01, 14),
                            AccountID = 1
                        },
                        new Models.Transaction
                        {
                            ID = 3,
                            TransactionType = Models.TransactionType.WithDrawal,
                            Amount = 300,
                            TransactionDate = new DateTime(2004, 11, 05),
                            AccountID = 2
                        },
                        new Models.Transaction
                        {
                            ID = 4,
                            TransactionType = Models.TransactionType.Lodgement,
                            Amount = 200,
                            TransactionDate = new DateTime(2014, 10, 25),
                            AccountID = 3
                        },
                        new Models.Transaction
                        {
                            ID = 5,
                            TransactionType = Models.TransactionType.Lodgement,
                            Amount = 1000,
                            TransactionDate = new DateTime(2011, 05, 09),
                            AccountID = 4
                        },
                        new Models.Transaction
                        {
                            ID = 6,
                            TransactionType = Models.TransactionType.WithDrawal,
                            Amount = 1000,
                            TransactionDate = new DateTime(2010, 02, 14),
                            AccountID = 5
                        },
                        new Models.Transaction
                        {
                            ID = 7,
                            TransactionType = Models.TransactionType.WithDrawal,
                            Amount = 1000,
                            TransactionDate = new DateTime(2004, 10, 04),
                            AccountID = 6
                        }
                    );

                context.SaveChanges();
            }
        }

        private void SeedAccounts(ClassContext context)
        {
            if (context.Accounts.Select(c => c).Count() == 0)
            {
                context.Accounts.AddOrUpdate(c => c.ID,
                        new Models.Account
                        {
                            ID = 1,
                            AccountName = "Current 1",
                            InceptionDate = new DateTime(2002, 01, 12),
                            CustomerID = 1,
                            CurrentBalance = 30000,
                            AccountTypeID = 1
                        },
                        new Models.Account
                        {
                            ID = 2,
                            AccountName = "Current 2",
                            InceptionDate = new DateTime(2004, 10, 31),
                            CustomerID = 1,
                            CurrentBalance = 20000,
                            AccountTypeID = 1
                        },
                        new Models.Account
                        {
                            ID = 3,
                            AccountName = "Deposit 1",
                            InceptionDate = new DateTime(2014, 10, 10),
                            CustomerID = 2,
                            CurrentBalance = 10000,
                            AccountTypeID = 3
                        },
                        new Models.Account
                        {
                            ID = 4,
                            AccountName = "Deposit 1",
                            InceptionDate = new DateTime(2011, 05, 03),
                            CustomerID = 3,
                            CurrentBalance = 50000,
                            AccountTypeID = 3
                        },
                        new Models.Account
                        {
                            ID = 5,
                            AccountName = "Savings 1",
                            InceptionDate = new DateTime(2010, 02, 02),
                            CustomerID = 2,
                            CurrentBalance = 3000,
                            AccountTypeID = 2
                        },
                        new Models.Account
                        {
                            ID = 6,
                            AccountName = "Current 1",
                            InceptionDate = new DateTime(2004, 09, 29),
                            CustomerID = 3,
                            CurrentBalance = 10000,
                            AccountTypeID = 1
                        }
                    );
                context.SaveChanges();
            }
        }

        private void SeedAccountTypes(ClassContext context)
        {
            if (context.AccountTypes.Select(at => at).Count() == 0)
            {
                context.AccountTypes.AddOrUpdate(at => at.ID,
                        new Models.AccountType
                        {
                            ID = 1,
                            TypeName = "Current",
                            Conditions = "Current Account Terms and conditions apply."
                        },
                        new Models.AccountType
                        {
                            ID = 2,
                            TypeName = "Savings",
                            Conditions = "Savings Account Terms and conditions apply."
                        },
                        new Models.AccountType
                        {
                            ID = 3,
                            TypeName = "Deposit",
                            Conditions = "Deposit Account Terms and conditions apply."
                        }
                    );
                context.SaveChanges();
            }
        }

        private void SeedCustomers(ClassContext context)
        {
            if (context.Customers.Select(c => c).Count() == 0)
            {
                context.Customers.Add(new Customer
                {
                    ID = 1,
                    Name = "Customer 1",
                    Address = "Address for Customer 1"
                });
                context.Customers.Add(new Models.Customer
                {
                    ID = 2,
                    Name = "Customer 2",
                    Address = "Address for Customer 2"
                });
                context.Customers.Add(new Models.Customer
                {
                    ID = 3,
                    Name = "Customer 3",
                    Address = "Address for Customer 3"
                });
                context.SaveChanges();
            }
        }
    }
}
