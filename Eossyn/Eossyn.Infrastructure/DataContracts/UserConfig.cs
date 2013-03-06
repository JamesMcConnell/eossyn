using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Eossyn.Infrastructure.DataContracts
{
    [DataContract]
    public class UserConfig
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "isLoggedIn")]
        public bool IsLoggedIn { get; set; }
    }
}
