using System;
using Ninject.Modules;

namespace Eossyn.Infrastructure.Injection
{
    using Core.Authentication;
    using Core.Encryption;
    using Core.Web;
    using Data.Repositories;
    using Infrastructure.Managers;

    public class EossynNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticationService>().To<FormsAuthenticationService>().InTransientScope();
            Bind<IHasherService>().To<HasherService>().InTransientScope();
            Bind<IUserManager>().To<UserManager>().InTransientScope();
            Bind<IUserRepository>().To<UserRepository>().InTransientScope();
            Bind<IUserSessionRepository>().To<UserSessionRepository>().InTransientScope();
            Bind<IUserSessionManager>().To<UserSessionManager>().InTransientScope();
            Bind<ISessionUtility>().To<SessionUtility>().InTransientScope();
        }
    }
}
