namespace Eossyn.Core.Authentication
{
    using System;

    public interface IAuthenticationService
    {
        /// <summary>
        /// Signs in the user.
        /// </summary>
        /// <param name="userName">The UserName of the user to sign in.</param>
        /// <param name="userData">Any extra user data (e.g. role).</param>
        /// <param name="createPersistentCookie">Determines whether to store the cookie.</param>
        /// <param name="expirationDate">The date at which the cookie expires.</param>
        void SignIn(string userName, string userData, bool createPersistentCookie, DateTime expirationDate);
        /// <summary>
        /// Signs the user out.
        /// </summary>
        void SignOut();
        /// <summary>
        /// Returns whether or not the current user is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }
        /// <summary>
        /// Retrieves the UserName of the currently logged in user.
        /// </summary>
        /// <returns>The currently logged in users UserName.</returns>
        string FetchName();
    }
}
