namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

	public interface IUserRepository
	{
        /// <summary>
        /// Retrieves all users in the database.
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}" /> of type <see cref="User" />.</returns>
		IQueryable<User> FetchAll();
        /// <summary>
        /// Retrieves a user for the given UserId.
        /// </summary>
        /// <param name="userId">The UserId parameter.</param>
        /// <returns>The requested <see cref="User" /> object.</returns>
		User FetchById(Guid userId);
        /// <summary>
        /// Retrieves a user for the given UserName.
        /// </summary>
        /// <param name="userName">The UserName parameter.</param>
        /// <returns>The requested <see cref="User" /> object.</returns>
		User FetchByUserName(string userName);
        /// <summary>
        /// Retrieves a user for the given EmailAddress.
        /// </summary>
        /// <param name="emailAddress">The EmailAddress parameter.</param>
        /// <returns>The requested <see cref="User" /> object.</returns>
		User FetchByEmail(string emailAddress);
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The <see cref="User" /> to create.</param>
		void Insert(User user);
        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user">The <see cref="User" /> object to update.</param>
		void Update(User user);
	}
}
