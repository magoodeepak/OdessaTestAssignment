using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odessa.VideoRental.Messages
{
    [DataContract()]
    public enum ResponseCodeEnum
    {
        [EnumMember()]
        ResponseOk,
        [EnumMember()]
        ResponseDataError,
        [EnumMember()]
        ResponseBusinessRuleVoilation,
    }
}
