using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.Messages;

namespace Odessa.VideoRental.PersistenceLogic
{
    public class RepositoryCustomer : RepositoryEntityStore<Customer>
    {
        public override Customer Save(Customer instance)
        {
            Customer response = instance;
            response.UniqueNumber = Guid.NewGuid().ToString();
            response.Id = RepositoryMap.Count + 1;
            RepositoryMap.Add(response.Id, instance);
            return response;
        }

        public override void Update(Customer instance)
        {
            Customer customer = RepositoryMap.Values.FirstOrDefault(p => p.UniqueNumber == instance.UniqueNumber);
            RepositoryMap.Remove(customer.Id);
            RepositoryMap.Add(customer.Id, instance);
        }

        public override void Remove(Customer instance)
        {
            throw new NotImplementedException();
        }

        //private readonly IDictionary<type,> Setters = new Dictionary<type,>();
    }
}
