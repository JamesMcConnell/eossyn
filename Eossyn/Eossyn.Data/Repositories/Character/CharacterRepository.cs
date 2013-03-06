namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;
    
    public class CharacterRepository : ICharacterRepository
    {
        private readonly EossynEntities db = new EossynEntities();

        public IQueryable<UserCharacter> FetchAllByUser(Guid userId)
        {
            return from c in db.UserCharacters
                   where c.UserId == userId
                   select c;
        }

        public IQueryable<UserCharacter> FetchAllByUserAndWorld(Guid userId, Guid worldId)
        {
            return from c in db.UserCharacters
                   where c.UserId == userId && c.WorldId == worldId
                   select c;
        }

        public UserCharacter FetchById(Guid userCharacterId)
        {
            return (from c in db.UserCharacters
                    where c.UserCharacterId == userCharacterId
                    select c).SingleOrDefault();
        }

        public void Create(UserCharacter userCharacter)
        {
            throw new NotImplementedException();
        }

        public void Update(UserCharacter userCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
