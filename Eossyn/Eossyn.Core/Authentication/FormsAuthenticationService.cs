namespace Eossyn.Core.Authentication
{
    using System;
    using System.Web;
    using System.Web.Security;

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
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
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
