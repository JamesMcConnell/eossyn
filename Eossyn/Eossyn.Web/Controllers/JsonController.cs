using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eossyn.Data.Repositories;
using Eossyn.Infrastructure.Managers;

namespace Eossyn.Web.Controllers
{
    public class JsonController : Controller
    {
        private readonly IWorldRepository _worldRepo;
        private IUserManager _userManager;
        private ICharacterRepository _characterRepo;

        public JsonController(IWorldRepository worldRepo, ICharacterRepository characterRepo, IUserManager userManager)
        {
            _worldRepo = worldRepo;
            _characterRepo = characterRepo;
            _userManager = userManager;
        }

        public JsonResult GetAllWorlds()
        {
            var allWorlds = from w in _worldRepo.FetchAll()
                            select new
                            {
                                WorldId = w.WorldId,
                                WorldName = w.WorldName
                            };
            return Json(allWorlds, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCharactersForWorld(Guid worldId)
        {
            var currentUserName = _userManager.FetchLoggedInUserName();
            var currentUser = _userManager.FetchUserByUserName(currentUserName);
            var userCharacters = _characterRepo.FetchAllByUserAndWorld(currentUser.UserId, worldId).Select(x => new
            {
                CharacterName = x.CharacterName,
                CharacterRace = x.CharacterRace.Description,
                CharacterClass = x.CharacterClass.Description
            });

            return Json(userCharacters, JsonRequestBehavior.AllowGet);
        }
    }
}
