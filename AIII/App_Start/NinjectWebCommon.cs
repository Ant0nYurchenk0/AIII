[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AIII.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AIII.App_Start.NinjectWebCommon), "Stop")]

namespace AIII.App_Start
{
    using AIII.Controllers.Api;
    using AIII.Models;
    using AIII.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

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
            kernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>();
            kernel.Bind<UserRatingAPIController>().To<UserRatingAPIController>();
            kernel.Bind<UserRatingRepository>().To<UserRatingRepository>();
            kernel.Bind<CustomMoviesAPIController>().To<CustomMoviesAPIController>();
            kernel.Bind<IImdbApiController>().To<ImdbApiController>();
            kernel.Bind<ImdbRepository>().To<ImdbRepository>();
            kernel.Bind<MovieRepository>().To<MovieRepository>();
        }
    }
}
