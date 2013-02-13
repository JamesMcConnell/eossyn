namespace Eossyn.ServiceContracts
{
    using System;
    using NServiceBus;

    public class UserSessionEnd : IMessage
    {
        public Guid UserSessionId { get; set; }
    }
}
