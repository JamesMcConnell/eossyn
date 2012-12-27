using System;
using System.Linq;
using Eossyn.Models;

namespace Eossyn.Data.Repositories
{
	public interface IUserRepository
	{
		IQueryable<User> FetchAll();

		User FetchById(Guid userId);
		User FetchByUserName(string userName);
		User FetchByEmail(string emailAddress);

		void Insert(User user);
		void Update(User user);
	}
}
