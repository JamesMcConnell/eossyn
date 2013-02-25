[assembly: WebActivator.PreApplicationStartMethod(typeof(Eossyn.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Eossyn.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Eossyn.Web.App_Start
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;

	using Core.Authentication;
	using Core.Encryption;
    using Core.Web;
	using Data.Repositories;
    using Infrastructure.Managers;
    using System.Web.Http;
    using Infrastructure.Injection;

	public static class NinjectWebCommon 
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start() 
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}
		
		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}
		
		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
			
			RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
            kernel.Bind<IAuthenticationService>().To<FormsAuthenticationService>().InTransientScope();
            kernel.Bind<IHasherService>().To<HasherService>().InTransientScope();
            kernel.Bind<IUserManager>().To<UserManager>().InTransientScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InTransientScope();
            kernel.Bind<IUserSettingRepository>().To<UserSettingRepository>().InTransientScope();
            kernel.Bind<IUserSessionRepository>().To<UserSessionRepository>().InTransientScope();
            kernel.Bind<IWorldRepository>().To<WorldRepository>().InTransientScope();
            kernel.Bind<IUserSessionManager>().To<UserSessionManager>().InTransientScope();
            kernel.Bind<ISessionUtility>().To<SessionUtility>().InTransientScope();
		}        
	}
}
