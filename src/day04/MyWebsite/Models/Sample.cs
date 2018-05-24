namespace MyWebsite.Models
{
    public interface ISample
    {
        int Id { get; }
    }

    public interface ISampleTransient : ISample
    {
    }

    public interface ISampleScoped : ISample
    {
    }

    public interface ISampleSingleton : ISample
    {
    }

    public class Sample : ISampleTransient, ISampleScoped, ISampleSingleton
    {
        private static int _counter;
        private int _id;

        public Sample()
        {
            _id = ++_counter;
        }

        public int Id => _id;
    }
}