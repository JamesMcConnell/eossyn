using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public IEnumerable<WorldListItem> Get()
        {
            return _repo.FetchAll().Select(x => new WorldListItem
            {
                WorldId = x.WorldId,
                WorldName = x.WorldName
            });
        }

        // GET api/world/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/world
        public void Post([FromBody]string value)
        {
        }

        // PUT api/world/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/world/5
        public void Delete(int id)
        {
        }
    }
}
