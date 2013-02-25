namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public class WorldRepository : IWorldRepository
    {
        private readonly EossynEntities db = new EossynEntities();

        public IQueryable<World> FetchAll()
        {
            return from w in db.Worlds
                   select w;
        }

        public World FetchById(Guid worldId)
        {
            return (from w in db.Worlds
                    where w.WorldId == worldId
                    select w).SingleOrDefault();
        }
    }
}
