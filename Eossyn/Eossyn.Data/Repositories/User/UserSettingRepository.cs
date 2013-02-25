namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public class UserSettingRepository : IUserSettingRepository
    {
        private readonly EossynEntities db = new EossynEntities();

        public UserSetting GetUserDefaults(Guid userId)
        {
            return db.UserSettings.FirstOrDefault(ud => ud.UserId == userId);
        }

        public void InsertUserSetting(UserSetting userDefault)
        {
            db.UserSettings.Add(userDefault);
            db.SaveChanges();
        }

        public void UpdateLastCharacter(Guid userId, Guid userCharacterId)
        {
            var dbUserDefault = db.UserSettings.FirstOrDefault(ud => ud.UserId == userId);
            dbUserDefault.LastUsedCharacterId = userCharacterId;
            db.SaveChanges();
        }

        public void UpdateLastWorld(Guid userId, Guid worldId)
        {
            var dbUserDefault = db.UserSettings.FirstOrDefault(ud => ud.UserId == userId);
            dbUserDefault.LastUsedWorldId = worldId;
            db.SaveChanges();
        }
    }
}
