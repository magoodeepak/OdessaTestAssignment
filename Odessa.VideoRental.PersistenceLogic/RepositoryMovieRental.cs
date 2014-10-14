using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.Messages;

namespace Odessa.VideoRental.PersistenceLogic
{
    public class RepositoryMovieRental : RepositoryEntityStore<MovieRentalItem>
    {
        public override MovieRentalItem Save(MovieRentalItem instance)
        {
            MovieRentalItem response = instance;
            response.Customer = instance.Customer;
            response.Movie = instance.Movie;
            response.MovieRentalItemUID = Guid.NewGuid().ToString();
            
            response.Id = RepositoryMap.Count + 1;
            RepositoryMap.Add(response.Id, instance);
            return response;
        }

        public override void Update(MovieRentalItem instance)
        {
            MovieRentalItem movieRentalItem = RepositoryMap.Values.FirstOrDefault(p => p.MovieRentalItemUID == instance.MovieRentalItemUID);
            RepositoryMap.Remove(movieRentalItem.Id);
            RepositoryMap.Add(movieRentalItem.Id,instance);
        }

        public override void Remove(MovieRentalItem instance)
        {
            throw new NotImplementedException();
        }

        
    }
}
