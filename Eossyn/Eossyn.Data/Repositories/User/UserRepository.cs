using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eossyn.Data;

namespace Eossyn.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region IUserRepository Members
        public IQueryable<User> FetchAll()
        {
            using (EossynEntities context = new EossynEntities())
            {
                return context.Users.AsQueryable();
            }
        }
        #endregion
    }
}
