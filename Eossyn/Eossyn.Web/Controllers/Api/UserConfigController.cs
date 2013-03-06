using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eossyn.Infrastructure.Managers;
using Eossyn.Infrastructure.Web;
using Eossyn.Infrastructure.DataContracts;

namespace Eossyn.Web.Controllers.Api
{
    public class UserConfigController : ApiController
    {
        private IUserManager _userManager;
        private DataContractJsonResult _jsonResult;

        public UserConfigController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET api/userconfig
        public UserConfig Get()
        {
            return new UserConfig
            {
                UserName = _userManager.FetchLoggedInUserName(),
                IsLoggedIn = _userManager.IsAuthenticated
            };
        }
    }
}
