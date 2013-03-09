namespace Eossyn.Infrastructure.Managers
{
    using System;
    using Models;

    public interface IUserSessionManager
    {
        /// <summary>
        /// Retrieves the current <see cref="UserSession" /> from Session.
        /// </summary>
        /// <returns>The requested <see cref="UserSession" /> object.</returns>
        UserSession FetchCurrentUserSession();
        /// <summary>
        /// Retrieves the most recent active <see cref="UserSession" /> for the given <see cref="User" />.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User" />.</param>
        /// <returns>The requested <see cref="UserSession" /> object.</returns>
        UserSession FetchMostRecentUserSession(Guid userId);
        /// <summary>
        /// Determines whether or not the given userId has an active user session.
        /// </summary>
        /// <param name="userId">The UserId parameter to search for.</param>
        /// <returns>True if there is an active user session for the given UserId, else false.</returns>
        bool UserSessionExists(Guid userId);
        /// <summary>
        /// Updates the current <see cref="UserSession" /> object in session with the given UserCharacterId.
        /// This is updated in Session as well as in the database.
        /// </summary>
        /// <param name="userCharacterId">The UserCharacterId parameter to update.</param>
        void UpdateCurrentCharacter(Guid userCharacterId);
        /// <summary>
        /// Updates the current <see cref="UserSession" /> object in session with the given WorldId.
        /// This is updated in Session as well as in the database.
        /// </summary>
        /// <param name="worldId">The WorldId parameter to udpate.</param>
        void UpdateCurrentWorld(Guid worldId);
        /// <summary>
        /// Creates a new UserSession for the given UserId, UserCharacterId and WorldId.
        /// This is created in Session as well as in the database.
        /// </summary>
        /// <param name="userId">The UserId parameter.</param>
        /// <param name="userCharacterId">The UserCharacterId parameter.</param>
        /// <param name="worldId">The WorldId parameter.</param>
        void CreateUserSession(Guid userId, Guid userCharacterId, Guid worldId);
        /// <summary>
        /// This updates the LastUpdated property of the current <see cref="UserSession" /> object.
        /// This is updated in Session as well as in the database.
        /// </summary>
        void UpdateUserSession();
        /// <summary>
        /// This updates the EndedTime property of the current <see cref="UserSession" /> object.
        /// This is updated in Session as well as in the database and removes the <see cref="UserSession" /> object from Session.
        /// </summary>
        void EndUserSession();
    }
}
