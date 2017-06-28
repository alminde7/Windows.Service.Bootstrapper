using Topshelf;

namespace Windows.Service.Bootstrapper
{
    public class Service
    {
        /// <summary>
        /// This will bootstrap a Windows Service. An implementation of IService is necessesary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <remarks>
        /// Parameter T must implement interface IService.
        /// </remarks>
        public static void Bootstrap<T>() where T : class, IService, new() // Note to self. class -> implementation; IService -> T is of type IService; new() -> can be newed
        {
            HostFactory.Run(x =>
            {
                x.UseLinuxIfAvailable();
                x.Service<T>(s =>
                {
                    s.ConstructUsing(service => new T());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.SetServiceName(ServiceConfig.ServiceName);
                x.SetDescription(ServiceConfig.ServiceDescription);
                x.SetDisplayName(ServiceConfig.ServiceName);

                x.StartAutomatically();
            });
        }
    }
}
