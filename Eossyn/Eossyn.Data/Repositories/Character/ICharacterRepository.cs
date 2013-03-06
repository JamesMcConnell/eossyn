namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public interface ICharacterRepository
    {
        IQueryable<UserCharacter> FetchAllByUser(Guid userId);
        IQueryable<UserCharacter> FetchAllByUserAndWorld(Guid userId, Guid worldId);
        UserCharacter FetchById(Guid userCharacterId);

        void Create(UserCharacter userCharacter);
        void Update(UserCharacter userCharacter);
    }
}
