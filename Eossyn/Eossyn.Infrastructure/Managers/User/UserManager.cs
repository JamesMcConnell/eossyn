namespace Eossyn.Infrastructure.Managers
{
    using System;
    using Core.Authentication;
    using Core.Encryption;
    using Data.Repositories;
    using Models;

    public class UserManager : IUserManager
    {
        private IAuthenticationService _authService;
		private IHasherService _hashService;
		private IUserRepository _userRepo;
        private IUserSettingRepository _userDefaultRepo;

		public UserManager(IAuthenticationService authService, IHasherService hashService, IUserRepository userRepo, IUserSettingRepository userDefaultRepo)
		{
			_authService = authService;
			_hashService = hashService;
			_userRepo = userRepo;
            _userDefaultRepo = userDefaultRepo;
        }

        #region IUserManager Methods
        public void SignIn(string userName, bool createPersistentCookie)
        {
            _authService.SignIn(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            _authService.SignOut();
        }

        public bool IsAuthenticated
        {
            get { return _authService.IsAuthenticated; }
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

        public User FetchLoggedInUser()
        {
            return _userRepo.FetchByUserName(_authService.FetchName());
        }

        public void CreateUser(string userName, string emailAddress, string password)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
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

        public User FetchUserByUserName(string userName)
        {
            return _userRepo.FetchByUserName(userName);
        }

        public void UpdateLastUsedCharacter(Guid userId, Guid userCharacterId)
        {
            _userDefaultRepo.UpdateLastCharacter(userId, userCharacterId);
        }

        public void UpdateLastUsedWorld(Guid userId, Guid worldId)
        {
            _userDefaultRepo.UpdateLastWorld(userId, worldId);
        }
        #endregion
    }
}
