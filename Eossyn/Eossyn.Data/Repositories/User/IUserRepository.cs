using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eossyn.Data;

namespace Eossyn.Data.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> FetchAll();
    }
}
