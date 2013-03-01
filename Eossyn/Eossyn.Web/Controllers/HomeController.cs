using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NServiceBus;
using Eossyn.Infrastructure.Managers;
using Eossyn.Infrastructure.Web;
using Eossyn.Data.Repositories;

namespace Eossyn.Web.Controllers
{
    public class HomeController : Controller
    {
        //public IBus Bus { get; set; }
        public IUserManager UserManager { get; set; }
        public ICharacterRepository CharacterRepo { get; set; }

        public HomeController(IUserManager userManager, ICharacterRepository characterRepo)
        {
            UserManager = userManager;
            CharacterRepo = characterRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCharactersForWorld(Guid id)
        {
            var currentUserName = UserManager.FetchLoggedInUserName();
            var currentUser = UserManager.FetchUserByUserName(currentUserName);
            var userCharacters = CharacterRepo.FetchAllByUserAndWorld(currentUser.UserId, id).Select(x => new
            {
                CharacterName = x.CharacterName,
                CharacterRace = x.CharacterRace.Description,
                CharacterClass = x.CharacterClass.Description
            });

            return Json(userCharacters, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult UserSettings()
        //{
        //    DataContractJsonResult result = new DataContractJsonResult();
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
