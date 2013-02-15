using Ninject;

namespace Eossyn.Infrastructure.Injection
{
    public class NinjectConfiguration
    {
        public static IKernel CreateNinjectKernel()
        {
            return new StandardKernel(new EossynNinjectModule());
        }
    }
}
