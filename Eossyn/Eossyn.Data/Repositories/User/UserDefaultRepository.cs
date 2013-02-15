namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public class UserDefaultRepository : IUserDefaultRepository
    {
        private readonly EossynEntities db = new EossynEntities();

        public UserDefault GetUserDefaults(Guid userId)
        {
            return db.UserDefaults.FirstOrDefault(ud => ud.UserId == userId);
        }

        public void InsertUserDefaults(UserDefault userDefault)
        {
            db.UserDefaults.Add(userDefault);
            db.SaveChanges();
        }

        public void UpdateLastCharacter(Guid userId, Guid userCharacterId)
        {
            var dbUserDefault = db.UserDefaults.FirstOrDefault(ud => ud.UserId == userId);
            dbUserDefault.LastUsedCharacterId = userCharacterId;
            db.SaveChanges();
        }

        public void UpdateLastWorld(Guid userId, Guid worldId)
        {
            var dbUserDefault = db.UserDefaults.FirstOrDefault(ud => ud.UserId == userId);
            dbUserDefault.LastUsedWorldId = worldId;
            db.SaveChanges();
        }
    }
}
