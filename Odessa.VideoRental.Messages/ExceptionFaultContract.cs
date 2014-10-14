using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Odessa.VideoRental.Messages
{
    [DataContract]
    public class ExceptionFaultContract
    {
        [DataMember]
        public string Description
        {
            get;
            set;
        }
        
        [DataMember]
        public string Message
        {
            get;
            set;
        }

    }
}
