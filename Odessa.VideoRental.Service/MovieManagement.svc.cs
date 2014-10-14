using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Odessa.VideoRental.BusinessRules;
using Odessa.VideoRental.Messages;
using Odessa.VideoRental.PersistenceLogic;

namespace Odessa.VideoRental.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovieManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MovieManagement.svc or MovieManagement.svc.cs at the Solution Explorer and start debugging.
    public class MovieManagement : IMovieManagement
    {
        private const string Invalid_Movie_Name = "Movie name is invalid";

        public ResponseEnvelope<Movie> AddMovie(Movie movie)
        {
            ResponseEnvelope<Movie> response = new ResponseEnvelope<Movie>();
            if (movie == null)
            {
                ExceptionFaultContract ex = new ExceptionFaultContract();
                ex.Message = "ArgumentNullException";
                ex.Description = "Customer contract is not initialzed.";
                throw new FaultException<ExceptionFaultContract>(ex);
            }

            if (!MovieManagementBusinessRule.ValidateMovie(movie))
            {
                response.ResponseCode = ResponseCodeEnum.ResponseBusinessRuleVoilation;
                response.ResponseMessage = Invalid_Movie_Name;
            }
            else
            {
                RepositoryMovie rep = new RepositoryMovie();
                Movie newObject = rep.Save(movie);
                response.ResponseCode = ResponseCodeEnum.ResponseOk;
                response.ResponseMessage = newObject.Id.ToString();
            }
            return response;
        }

        public ResponseEnvelope<Movie> GetAllMovies()
        {
            RepositoryMovie rep = new RepositoryMovie();
            ResponseEnvelope<Movie> response = new ResponseEnvelope<Movie>();
            response.List = rep.FindAll().ToList<Movie>();
            response.ResponseCode = ResponseCodeEnum.ResponseOk;
            return response;
        }

    }
}
