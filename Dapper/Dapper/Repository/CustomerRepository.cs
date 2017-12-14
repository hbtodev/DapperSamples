using DapperSample.Infrastructure;
using DapperSample.Model;
using System.Linq;
using Dapper;
using System;

namespace DapperSample.Repository
{
    public class CustomerRepository
    {
        private DataBase dataBase;

        public CustomerRepository()
        { }

        public Customer FindOne()
        {
            Customer customerReturn = new Customer();
            dataBase = new DataBase();

            try
            {
                var dbContext = dataBase.Connect();
                if (dbContext != null)
                {
                    customerReturn = dbContext.Query<Customer>("Select *from Customer") .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return customerReturn;
        }

        public Customer FindById(Guid Id)
        {
            Customer customerReturn = new Customer();
            dataBase = new DataBase();

            try
            {
                var dbContext = dataBase.Connect();
                if (dbContext != null)
                {
                    customerReturn = dbContext.Query<Customer>("Select *from Customer where IdCustomer=@IdCustomer", new { IdCustomer = Id }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return customerReturn;
        }

        public bool Insert(Customer customer)
        {
            dataBase = new DataBase();
            bool inserted = false;

            try
            {
                var dbContext = dataBase.Connect();
                if (dbContext != null)
                {
                    dbContext.Execute(@"Insert Customer(IdCustomer,Name, Email) 
                                        values(@IdCustomer, @Name, @Email)",customer);

                    inserted = true;
               }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return inserted;
        }

        public void Disconnect()
        {
            this.dataBase.Disconect();

        }
    }
}
