using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.Messages;

namespace Odessa.VideoRental.PersistenceLogic
{
    public class RepositoryMovie : RepositoryEntityStore<Movie>
    {
        public override Movie Save(Movie instance)
        {
            Movie response = instance;
            response.Id = RepositoryMap.Count + 1;
            RepositoryMap.Add(response.Id, instance);
            return response;
        }

        public override void Update(Movie instance)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Movie instance)
        {
            throw new NotImplementedException();
        }


    }
}
