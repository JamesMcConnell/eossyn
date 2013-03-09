namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public class UserSettingRepository : IUserSettingRepository
    {
        private readonly EossynEntities db = new EossynEntities();

        public UserSetting GetUserSettings(Guid userId)
        {
            return db.UserSettings.FirstOrDefault(ud => ud.UserId == userId);
        }

        public void InsertUserSetting(UserSetting userSetting)
        {
            db.UserSettings.Add(userSetting);
            db.SaveChanges();
        }

        public void UpdateLastCharacter(Guid userId, Guid userCharacterId)
        {
            var dbUserSetting = db.UserSettings.FirstOrDefault(ud => ud.UserId == userId);
            dbUserSetting.LastUsedCharacterId = userCharacterId;
            db.SaveChanges();
        }

        public void UpdateLastWorld(Guid userId, Guid worldId)
        {
            var dbUserSetting = db.UserSettings.FirstOrDefault(ud => ud.UserId == userId);
            dbUserSetting.LastUsedWorldId = worldId;
            db.SaveChanges();
        }
    }
}
