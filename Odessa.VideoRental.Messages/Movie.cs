using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odessa.VideoRental.Messages
{
    [DataContract]
    public class Movie
    {

        [DataMember]
        public MovieCategoryEnum Category
        {
            get;
            set;
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }
          
    }
}
