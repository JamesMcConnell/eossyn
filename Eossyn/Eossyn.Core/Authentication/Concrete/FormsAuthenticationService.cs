using System;
using System.Web;
using System.Web.Security;

namespace Eossyn.Core.Authentication.Concrete
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly FormsAuthenticationTicket _ticket;

        public FormsAuthenticationService()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                string encTicket = authCookie.Value;
                if (!string.IsNullOrEmpty(encTicket))
                {
                    _ticket = FormsAuthentication.Decrypt(encTicket);
                }
            }
        }

        #region IAuthenticationService Members
        public void SignIn(string userName, string userData, bool createPersistentCookie, DateTime expirationDate)
        {
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
                2,
                userName,
                DateTime.Now,
                expirationDate,
                createPersistentCookie,
                userData,
                FormsAuthentication.FormsCookiePath
            );

            string hash = FormsAuthentication.Encrypt(newTicket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            if (newTicket.IsPersistent)
            {
                cookie.Expires = newTicket.Expiration;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public bool IsAuthenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public string FetchName()
        {
            return (_ticket == null) ? string.Empty : _ticket.Name;
        }
        #endregion
    }
}
