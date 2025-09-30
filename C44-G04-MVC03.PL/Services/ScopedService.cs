
namespace C44_G04_MVC03.PL.Services
{
    public class ScopedService : IScopedService
    {
        public ScopedService()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get ; set ; }

        public string GetGuid()
        {

            return Guid.ToString();
        }
    }
}
