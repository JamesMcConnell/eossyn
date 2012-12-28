namespace Eossyn.Infrastructure.Managers
{
    using System;
    using Models;

    public interface IUserManager
    {
        /// <summary>
        /// Signs in the current user.
        /// </summary>
        /// <param name="userName">The UserName of the user to sign in.</param>
        /// <param name="userData">Any extra data (e.g. role).</param>
        /// <param name="createPersistentCookie">Determines whether or not to store the cookie.</param>
        /// <param name="expiration">The date at which the cookie expires.</param>
        void SignIn(string userName, string userData, bool createPersistentCookie, DateTime expiration);
        /// <summary>
        /// Signs the user out.
        /// </summary>
        void SignOut();
        /// <summary>
        /// Determines whether or not the user can be logged in.
        /// </summary>
        /// <param name="userName">The UserName of the user attempting to log in.</param>
        /// <param name="password">The password of the user attempting to log in.</param>
        /// <returns>True if the user can be logged in, else false.</returns>
        bool ValidateLogin(string userName, string password);
        /// <summary>
        /// Retrieves the UserName of the currently logged in user.
        /// </summary>
        /// <returns>The currently logged in users UserName.</returns>
        string FetchLoggedInUserName();
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userName">The UserName of the user to create.</param>
        /// <param name="emailAddress">The EmailAddress of the user to create.</param>
        /// <param name="password">The password of the user to create.</param>
        void CreateUser(string userName, string emailAddress, string password);
        /// <summary>
        /// Determines whether or not a user can register with the given information.
        /// </summary>
        /// <param name="userName">The UserName the user is attempting to register.</param>
        /// <param name="emailAddress">The email address the user is attempting to register with.</param>
        /// <returns>True if the user can register with the given information, else false.</returns>
        bool ValidateRegistration(string userName, string emailAddress);
    }
}
