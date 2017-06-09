[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication6.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApplication6.App_Start.NinjectWebCommon), "Stop")]

namespace WebApplication6.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using WebApplication6.Model;
    using WebApplication6.Mappers;
    using Ninject;
    using Ninject.Web.Common;
    using System.Configuration;
    using WebApplication6.Auth; 
    using System.Web.Mvc;
  
 

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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
              kernel.Bind<IMapper>().To<CommonMapper>().InRequestScope();
            kernel.Bind<DataClasses1DataContext>().ToMethod(c => new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["basev1ConnectionString"].ConnectionString));
            kernel.Bind<IRepository>().To<SqlRepository>().InRequestScope();
           

            kernel.Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();

        }        
    }
}