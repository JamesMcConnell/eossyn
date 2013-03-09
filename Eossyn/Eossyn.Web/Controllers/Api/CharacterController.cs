using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Eossyn.Data.Repositories;
using Eossyn.Infrastructure.DataContracts;
using Eossyn.Infrastructure.Managers;

namespace Eossyn.Web.Controllers.Api
{
    public class CharacterController : ApiController
    {
        private readonly ICharacterRepository _repo;
        private readonly IUserManager _userManager;

        public CharacterController(ICharacterRepository repo, IUserManager userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        // GET api/character
        public List<UserCharacterModel> Get()
        {
            var currentUserName = _userManager.FetchLoggedInUserName();
            var currentUser = _userManager.FetchUserByUserName(currentUserName);
            return _repo.FetchAllByUser(currentUser.UserId).ToList().Select(x => new UserCharacterModel
            {
                CharacterId = x.UserCharacterId.ToString(),
                CharacterName = x.CharacterName,
                CharacterRace = x.CharacterRace.Description,
                CharacterClass = x.CharacterClass.Description,
                CharacterLevel = x.CurrentLevel,
                WorldId = x.WorldId.ToString()
            }).ToList();
        }

        // GET api/character/5
        public UserCharacterModel Get(string id)
        {
            var userCharacterId = new Guid(id);
            var userCharacter = _repo.FetchById(userCharacterId);
            return new UserCharacterModel
            {
                CharacterId = userCharacter.UserCharacterId.ToString(),
                CharacterClass = userCharacter.CharacterClass.Description,
                CharacterRace = userCharacter.CharacterRace.Description,
                CharacterName = userCharacter.CharacterName,
                CharacterLevel = userCharacter.CurrentLevel,
                WorldId = userCharacter.WorldId.ToString()
            };
        }
    }
}
