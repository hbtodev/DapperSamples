using System;

namespace DapperSample.Model
{
    public class Customer
    {
        public Guid IdCustomer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer()
        {
        }

        public void ClearFields()
        {
            this.IdCustomer = Guid.Empty;
            this.Name = string.Empty;
            this.Email = string.Empty;
        }
    }
}
