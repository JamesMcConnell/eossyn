namespace Eossyn.Infrastructure.Services
{
	using System;
	using Models;

	public interface IUserService
	{
		void SignIn(string userName, string userData, bool createPersistentCookie, DateTime expiration);
		void SignOut();
		bool ValidateLogin(string userName, string password);
		string FetchLoggedInUserName();

		void CreateUser(string userName, string emailAddress, string password);
		bool ValidateRegistration(string userName, string emailAddress);
	}
}
