using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odessa.VideoRental.Messages
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public String AddressLine1
        {
            get;
            set;
        }

        [DataMember]
        public String AddressLine2
        {
            get;
            set;
        }

        [DataMember]
        public string City
        {
            get;
            set;
        }

        [DataMember]
        public StateEnum State
        {
            get;
            set;
        }
    }
}
