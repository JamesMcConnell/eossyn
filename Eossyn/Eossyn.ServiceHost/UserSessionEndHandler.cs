using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eossyn.ServiceContracts;
using NServiceBus;

namespace Eossyn.ServiceHost
{
    public class UserSessionEndHandler : IHandleMessages<UserSessionEnd>
    {
        public void Handle(UserSessionEnd message)
        {
            // Do something here
            string bp = "";
        }
    }
}
