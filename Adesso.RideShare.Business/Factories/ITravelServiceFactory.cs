using Adesso.RideShare.Business.Services;

namespace Adesso.RideShare.Business.Factories
{
    public interface ITravelServiceFactory
    {
        ITravelService Create();
    }
}
