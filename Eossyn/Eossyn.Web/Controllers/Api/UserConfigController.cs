using System;
using System.Web.Http;
using Eossyn.Data.Repositories;
using Eossyn.Infrastructure.DataContracts;
using Eossyn.Infrastructure.Managers;

namespace Eossyn.Web.Controllers.Api
{
    public class UserConfigController : ApiController
    {
        private IUserManager _userManager;
        private IUserSessionManager _userSessionManager;
        private IUserSettingRepository _userSettingRepo;
        private ICharacterRepository _characterRepo;
        private IWorldRepository _worldRepo;

        public UserConfigController(IUserManager userManager, IUserSessionManager userSessionManager, IUserSettingRepository userSettingRepo, ICharacterRepository characterRepo, IWorldRepository worldRepo)
        {
            _userManager = userManager;
            _userSessionManager = userSessionManager;
            _userSettingRepo = userSettingRepo;
            _characterRepo = characterRepo;
            _worldRepo = worldRepo;
        }

        // GET api/userconfig
        public UserConfigResponse Get()
        {
            var userConfigResponse = new UserConfigResponse();
            var userConfig = new UserConfig();
            var currentUser = _userManager.FetchLoggedInUser();

            // Not logged in
            if (currentUser == null)
            {
                userConfigResponse.IsAuthorized = false;
                userConfigResponse.UserConfig = null;
            }
            else
            {
                userConfigResponse.IsAuthorized = true;
                // Get current session if it exists
                var currentUserSession = _userSessionManager.FetchCurrentUserSession();
                if (currentUserSession == null)
                {
                    // Does not have an current session, get the most recent session
                    currentUserSession = _userSessionManager.FetchMostRecentUserSession(currentUser.UserId);
                    if (currentUserSession == null)
                    {
                        // Does not have a recent session, most likely a new/first time user
                        userConfigResponse.UserConfig = null;
                    }
                    else
                    {
                        userConfig.UserName = currentUser.UserName;
                        var lastUsedCharacter = _characterRepo.FetchById(currentUserSession.CurrentUserCharacterId);
                        var lastUsedWorld = _worldRepo.FetchById(currentUserSession.CurrentWorldId);
                        userConfig.CurrentCharacter = new UserCharacterModel
                        {
                            CharacterId = lastUsedCharacter.UserCharacterId.ToString(),
                            CharacterClass = lastUsedCharacter.CharacterClass.Description,
                            CharacterLevel = lastUsedCharacter.CurrentLevel,
                            CharacterName = lastUsedCharacter.CharacterName,
                            CharacterRace = lastUsedCharacter.CharacterRace.Description,
                            WorldId = lastUsedWorld.WorldId.ToString()
                        };
                        userConfig.CurrentWorld = new WorldModel
                        {
                            WorldId = lastUsedWorld.WorldId.ToString(),
                            WorldName = lastUsedWorld.WorldName
                        };
                    }
                }
                else
                {
                    userConfig.UserName = currentUser.UserName;
                    var lastUsedCharacter = _characterRepo.FetchById(currentUserSession.CurrentUserCharacterId);
                    var lastUsedWorld = _worldRepo.FetchById(currentUserSession.CurrentWorldId);
                    userConfig.CurrentCharacter = new UserCharacterModel
                    {
                        CharacterId = lastUsedCharacter.UserCharacterId.ToString(),
                        CharacterClass = lastUsedCharacter.CharacterClass.Description,
                        CharacterLevel = lastUsedCharacter.CurrentLevel,
                        CharacterName = lastUsedCharacter.CharacterName,
                        CharacterRace = lastUsedCharacter.CharacterRace.Description,
                        WorldId = lastUsedWorld.WorldId.ToString()
                    };
                    userConfig.CurrentWorld = new WorldModel
                    {
                        WorldId = lastUsedWorld.WorldId.ToString(),
                        WorldName = lastUsedWorld.WorldName
                    };
                }
            }

            return userConfigResponse;
        }
    }
}
