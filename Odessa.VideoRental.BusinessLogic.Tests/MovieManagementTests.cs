using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.BusinessLogic;
using Odessa.VideoRental.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace Odessa.VideoRental.BusinessLogic.Tests
{
    [TestClass()]
    public class MovieManagementTests
    {
        [TestMethod()]
        public void AddMovie_InvalidLastName_Negative()
        {
            Movie movie = new Movie();
            movie.Name = "MovieName001";
            movie.Category = MovieCategoryEnum.New;
            using (MovieService.MovieManagementClient client = new MovieService.MovieManagementClient())
            {
                ResponseEnvelope<Movie> response = client.AddMovie(movie);

                Console.Out.WriteLine(response.ResponseCode);
                Assert.IsTrue(response.ResponseCode != ResponseCodeEnum.ResponseOk);
            }
        }

        [TestMethod()]
        public void AddMovie_NullException_Negative()
        {
            try
            {

                Movie movie = null;

                using (MovieService.MovieManagementClient client = new MovieService.MovieManagementClient())
                {
                    ResponseEnvelope<Movie> response = client.AddMovie(movie);
                    Console.Out.WriteLine(response.ResponseCode);
                }
            }
            catch (FaultException ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
        }

        [TestMethod()]
        public void AddNewMovie_Positive()
        {
            Movie movie = new Movie();
            movie.Name = "MovieName001";
            movie.Category = MovieCategoryEnum.New;
            using(MovieService.MovieManagementClient client = new MovieService.MovieManagementClient())
            {
                ResponseEnvelope<Movie> response = client.AddMovie(movie);
            
                Console.Out.WriteLine(response.ResponseCode);
                Console.Out.WriteLine(response.ResponseMessage);
                Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk && !string.IsNullOrEmpty(response.ResponseMessage));
            }
        }

        [TestMethod()]
        public void AddKidsMovie_Positive()
        {
            Movie movie = new Movie();
            movie.Name = "MovieName002";
            movie.Category = MovieCategoryEnum.Kids;
            using (MovieService.MovieManagementClient client = new MovieService.MovieManagementClient())
            {
                ResponseEnvelope<Movie> response = client.AddMovie(movie);

                Console.Out.WriteLine(response.ResponseCode);
                Console.Out.WriteLine(response.ResponseMessage);
                Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk && !string.IsNullOrEmpty(response.ResponseMessage));
            }
        }

        [TestMethod()]
        public void AddRegularMovie_Positive()
        {
            Movie movie = new Movie();
            movie.Name = "MovieName003";
            movie.Category = MovieCategoryEnum.Regular;
            using (MovieService.MovieManagementClient client = new MovieService.MovieManagementClient())
            {
                ResponseEnvelope<Movie> response = client.AddMovie(movie);

                Console.Out.WriteLine(response.ResponseCode);
                Console.Out.WriteLine(response.ResponseMessage);
                Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk && !string.IsNullOrEmpty(response.ResponseMessage));
            }
        }

        [TestMethod()]
        public void GetMovies_Positive()
        {
            using (MovieService.MovieManagementClient client = new MovieService.MovieManagementClient())
            {
                ResponseEnvelope<Movie> response = client.GetAllMovies();
                foreach (var item in response.List)
                {
                    Console.Out.WriteLine(item.Name);
                }
                Console.Out.WriteLine(response.ResponseCode);
                Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }
    }
}
