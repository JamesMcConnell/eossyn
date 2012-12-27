namespace Eossyn.Infrastructure.Services
{
	using System;
	using Core.Authentication;
	using Core.Encryption;
	using Data.Repositories;
	using Models;

	public class UserService : IUserService
	{
		private IAuthenticationService _authService;
		private IHasherService _hashService;
		private IUserRepository _userRepo;

		public UserService(IAuthenticationService authService, IHasherService hashService, IUserRepository userRepo)
		{
			_authService = authService;
			_hashService = hashService;
			_userRepo = userRepo;
		}

		#region IUserService Methods
		public void SignIn(string userName, string userData, bool createPersistentCookie, DateTime expiration)
		{
			_authService.SignIn(userName, userData, createPersistentCookie, expiration);
		}

		public void SignOut()
		{
			_authService.SignOut();
		}

		public bool ValidateLogin(string userName, string password)
		{
			var user = _userRepo.FetchByUserName(userName);
			if (user == null || !user.IsEnabled)
			{
				return false;
			}

			var hashedPassword = _hashService.ComputeHash(password, user.Salt.ToString());
			if (user.Password != hashedPassword)
			{
				return false;
			}

			return true;
		}

		public string FetchLoggedInUserName()
		{
			return _authService.FetchName();
		}

		public void CreateUser(string userName, string emailAddress, string password)
		{
			var user = new User
			{
				UserName = userName,
				Salt = Guid.NewGuid(),
				EmailAddress = emailAddress,
				LastLoginDate = DateTime.Now,
				IsEnabled = true
			};

			user.Password = _hashService.ComputeHash(password, user.Salt.ToString());
			_userRepo.Insert(user);
		}

		public bool ValidateRegistration(string userName, string emailAddress)
		{
			var user = _userRepo.FetchByUserName(userName);
			if (user != null)
			{
				return false;
			}

			user = _userRepo.FetchByEmail(emailAddress);
			if (user != null)
			{
				return false;
			}

			return true;
		}
		#endregion
	}
}
