using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eossyn.Data.Repositories;
using Eossyn.Models;

namespace Eossyn.Web.Controllers.Api
{
    public class WorldController : ApiController
    {
        private readonly IWorldRepository _repo;

        public WorldController(IWorldRepository repo)
        {
            _repo = repo;
        }

        // GET api/world
        public dynamic Get()
        {
            return from w in _repo.FetchAll()
                   select new
                   {
                       WorldId = w.WorldId,
                       WorldName = w.WorldName
                   };
        }

        // GET api/world/5
        public World Get(Guid id)
        {
            return _repo.FetchById(id);
        }

        // POST api/world
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/world/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/world/5
        //public void Delete(int id)
        //{
        //}
    }
}
