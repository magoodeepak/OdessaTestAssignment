using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Odessa.VideoRental.Messages;
using Odessa.VideoRental.BusinessRules;

namespace Odessa.VideoRental.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovieManagement" in both code and config file together.
    [ServiceContract]
    public interface IMovieManagement
    {
        /// <summary>
        /// Saves the details of a movie
        /// </summary>
        /// <param name="movie">Movie object/DTO</param>
        /// <returns>Returns response object having newly constructed movie object</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<Movie> AddMovie(Movie movie);

        /// <summary>
        /// Get the list of all movies
        /// </summary>
        /// <returns>Returns response object having list of movie objects</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<Movie> GetAllMovies();
    }
}
