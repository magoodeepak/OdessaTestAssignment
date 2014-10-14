using Odessa.VideoRental.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odessa.VideoRental.BusinessRules
{
    public static class CustomerRegistrationBusinessRule
    {
        public static bool ValidateCustomer(Customer customer)
        {
            return customer.FirstName.Length <= 20 && customer.LastName.Length <= 20; 
        }
        
    }
}
