namespace Eossyn.Data.Repositories
{
    using System;
    using System.Linq;
    using Models;

	public class UserRepository : IUserRepository
	{
		private readonly EossynEntities db = new EossynEntities();

		#region IUserRepository Members
		public IQueryable<User> FetchAll()
		{
			return from u in db.Users
				   select u;
		}

		public User FetchById(Guid userId)
		{
			return (from u in db.Users
					where u.UserId == userId
					select u).SingleOrDefault();
		}
		
		public User FetchByUserName(string userName)
		{
			return (from u in db.Users
					where u.UserName == userName
					select u).SingleOrDefault();
		}

		public User FetchByEmail(string emailAddress)
		{
			return (from u in db.Users
					where u.EmailAddress == emailAddress
					select u).SingleOrDefault();
		}

		public void Insert(User user)
		{
			db.Users.Add(user);
			db.SaveChanges();
		}

		public void Update(User user)
		{
			db.SaveChanges();
		}
		#endregion
	}
}
