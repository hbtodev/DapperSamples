using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DapperSample.Model;
using DapperSample.Repository;

namespace Dapper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Init");
            Console.ReadKey();
                        
           // Repository object
            CustomerRepository customerRep = new CustomerRepository();

            // Search
            var customer = customerRep.FindOne();
            if (customer != null)
            {
                Console.WriteLine(customer.Name);
            }

            // AddNew
            Customer NewCustomer;
            Random varRandom = new Random();
            DateTime dateInit = DateTime.Now;

            int maxRecord = 101;

            for (int i = 0; i < maxRecord; i++)
            {
                NewCustomer = new Customer();
                NewCustomer.IdCustomer = Guid.NewGuid();
                NewCustomer.Name = Convert.ToString("Customer - " + DateTime.Now.Date.Day + DateTime.Now.Millisecond + varRandom.Next());
                NewCustomer.Email = "c@teste.com";
                if (customerRep.Insert(NewCustomer))
                {
                    customer = null;
                    customer = customerRep.FindById(NewCustomer.IdCustomer);
                }
                Console.WriteLine(customer.Name + " - " +  customer.Email);
            }

            Console.WriteLine(DateTime.Now.Subtract(dateInit));

            Console.ReadKey();
        }
    }
}
