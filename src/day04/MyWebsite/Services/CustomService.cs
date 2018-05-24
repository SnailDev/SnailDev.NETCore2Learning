using MyWebsite.Models;

namespace MyWebsite.Services
{
    public class CustomService
    {
        public ISample Transient { get; private set; }
        public ISample Scoped { get; private set; }
        public ISample Singleton { get; private set; }

        public CustomService(ISampleTransient transient,
            ISampleScoped scoped,
            ISampleSingleton singleton)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
        }
    }
}