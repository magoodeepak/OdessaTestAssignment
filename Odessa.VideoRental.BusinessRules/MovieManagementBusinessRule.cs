using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.Messages;

namespace Odessa.VideoRental.BusinessRules
{
    public static class MovieManagementBusinessRule
    {
        public static bool ValidateMovie(Movie movie)
        {
            return movie.Name.Length <= 20;
        }        
    }
}
