using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Eossyn.Data.Repositories;
using Eossyn.Infrastructure.DataContracts;

namespace Eossyn.Web.Controllers.Api
{
    public class WorldController : ApiController
    {
        private readonly IWorldRepository _repo;

        public WorldController(IWorldRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<WorldModel> Get()
        {
            return _repo.FetchAll().ToList().Select(x => new WorldModel
            {
                WorldId = x.WorldId.ToString(),
                WorldName = x.WorldName
            });
        }
    }
}
