using Microsoft.Practices.Unity;
using StudentsWebAPI.IRepository;
using StudentsWebAPI.Repository;
using System.Web.Http;
using Unity.WebApi;

namespace StudentsWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMarkRepository, MarkRepository>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}