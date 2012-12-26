using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eossyn.Models;

namespace Eossyn.Data.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> FetchAll();
    }
}
