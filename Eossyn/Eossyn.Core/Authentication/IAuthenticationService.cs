using System;

namespace Eossyn.Core.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(string userName, string userData, bool createPersistentCookie, DateTime expirationDate);
        void SignOut();
        bool IsAuthenticated { get; }
        string FetchName();
    }
}
