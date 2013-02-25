namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

    public interface IWorldRepository
    {
        /// <summary>
        /// Retrieves all worlds
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}" /> of type <see cref="World" />.</returns>
        IQueryable<World> FetchAll();
        /// <summary>
        /// Retrieves a single world for the given WorldId
        /// </summary>
        /// <param name="worldId">The WorldId parameter</param>
        /// <returns>The requested <see cref="World" /> entity.</returns>
        World FetchById(Guid worldId);
    }
}
