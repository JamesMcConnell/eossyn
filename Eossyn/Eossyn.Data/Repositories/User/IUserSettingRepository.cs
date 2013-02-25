namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public interface IUserSettingRepository
    {
        /// <summary>
        /// Retrieves the user defaults.
        /// </summary>
        /// <param name="userId">Id of the <see cref="User"/>.</param>
        /// <returns>The current <see cref="UserDefault"/>s for the given user.</returns>
        UserSetting GetUserDefaults(Guid userId);
        /// <summary>
        /// Inserts defaults for a given user.
        /// </summary>
        /// <param name="userDefault">The <see cref="UserDefault"/>s to insert.</param>
        void InsertUserSetting(UserSetting userDefault);
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
