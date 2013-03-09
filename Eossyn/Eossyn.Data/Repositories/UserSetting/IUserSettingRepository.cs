namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public interface IUserSettingRepository
    {
        /// <summary>
        /// Retrieves the user settings.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User" />.</param>
        /// <returns>The current <see cref="UserSetting"/> object for the given user.</returns>
        UserSetting GetUserSettings(Guid userId);
        /// <summary>
        /// Inserts defaults for a given user.
        /// </summary>
        /// <param name="userSetting">The <see cref="UserSetting"/> object to insert.</param>
        void InsertUserSetting(UserSetting userSetting);
        /// <summary>
        /// Updates the last character a user played.
        /// </summary>
        /// <param name="userId">Id of the current <see cref="User"/>.</param>
        /// <param name="userCharacterId">Id of the current <see cref="UserCharacter"/> the user played.</param>
        void UpdateLastCharacter(Guid userId, Guid userCharacterId);
        /// <summary>
        /// Updates the last world a user played in.
        /// </summary>
        /// <param name="userId">Id of the current <see cref="User"/>.</param>
        /// <param name="worldId">Id of the current <see cref="World"/> the user played in.
        void UpdateLastWorld(Guid userId, Guid worldId);
    }
}
