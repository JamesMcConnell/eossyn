namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public class UserSessionRepository : IUserSessionRepository
    {
        private readonly EossynEntities db = new EossynEntities();

        #region IUserSessionRepository Members
        public IQueryable<UserSession> FetchAll()
        {
            return from us in db.UserSessions
                   select us;
        }

        public UserSession FetchByUserSessionId(Guid userSessionId)
        {
            return (from us in db.UserSessions
                    where us.UserSessionId == userSessionId
                    select us).FirstOrDefault();
        }

        public UserSession FetchByUserId(Guid userId)
        {
            return (from us in db.UserSessions
                    where us.UserId == userId
                    select us).FirstOrDefault();
        }

        public void UpdateCurrentCharacter(Guid userSessionId, Guid userCharacterId)
        {
            var dbUserSession = FetchByUserSessionId(userSessionId);
            if (dbUserSession != null)
            {
                dbUserSession.CurrentUserCharacterId = userCharacterId;
                db.SaveChanges();
            }
        }

        public void UpdateCurrentWorld(Guid userSessionId, Guid worldId)
        {
            var dbUserSession = FetchByUserSessionId(userSessionId);
            if (dbUserSession != null)
            {
                dbUserSession.CurrentWorldId = worldId;
                db.SaveChanges();
            }
        }

        public void Insert(UserSession userSession)
        {
            db.UserSessions.Add(userSession);
            db.SaveChanges();
        }

        public void UpdateUserSession(Guid userSessionId)
        {
            var dbUserSession = FetchByUserSessionId(userSessionId);
            if (dbUserSession != null)
            {
                dbUserSession.LastUpdated = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void EndUserSession(Guid userSessionId)
        {
            var dbUserSession = FetchByUserSessionId(userSessionId);
            if (dbUserSession != null)
            {
                dbUserSession.IsActive = false;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
