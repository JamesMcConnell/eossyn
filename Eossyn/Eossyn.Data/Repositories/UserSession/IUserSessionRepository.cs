namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public interface IUserSessionRepository
    {
        /// <summary>
        /// Retrieves all user sessions in the database.
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}" /> of type <see cref="UserSession" />.</returns>
        IQueryable<UserSession> FetchAll();
        /// <summary>
        /// Retrieves a user session for the given UserSessionId.
        /// </summary>
        /// <param name="userSessionId">The UserSessionId parameter.</param>
        /// <returns>The requested <see cref="UserSession" /> object.</returns>
        UserSession FetchByUserSessionId(Guid userSessionId);
        /// <summary>
        /// Retrieves a user session for the given UserId that is currently active.
        /// </summary>
        /// <param name="userId">The UserId parameter.</param>
        /// <returns>The requested <see cref="UserSession" /> object.</returns>
        UserSession FetchActiveUserSessionByUserId(Guid userId);
        /// <summary>
        /// Updates the CurrentUserCharacterId column.
        /// </summary>
        /// <param name="userSessionId">The UserSessionId to update.</param>
        /// <param name="userCharacterId">The CurrentUserCharaterId to update to.</param>
        void UpdateCurrentCharacter(Guid userSessionId, Guid userCharacterId);
        /// <summary>
        /// Updates the CurrentWorldId column.
        /// </summary>
        /// <param name="userSessionId">The UserSessionId to update.</param>
        /// <param name="worldId">The CurrentWorldId to update to.</param>
        void UpdateCurrentWorld(Guid userSessionId, Guid worldId);
        /// <summary>
        /// Creates a new user session.
        /// </summary>
        /// <param name="userSession">The <see cref="UserSession" /> to create.</param>
        void Insert(UserSession userSession);
        /// <summary>
        /// Updates the LastUpdated column.
        /// </summary>
        /// <param name="userSessionId">The UserSessionId of the user session to update.</param>
        void UpdateUserSession(Guid userSessionId);
        /// <summary>
        /// Ends the user session by updating the EndedTime column.
        /// </summary>
        /// <param name="userSessionId">The UserSessionId of the user session to end.</param>
        void EndUserSession(Guid userSessionId);
    }
}
