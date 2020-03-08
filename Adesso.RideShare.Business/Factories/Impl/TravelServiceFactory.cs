using Adesso.RideShare.Business.Services;
using Adesso.RideShare.Business.Services.Impl;
using Adesso.RideShare.Core.CrossCuttingConcerns;

namespace Adesso.RideShare.Business.Factories.Impl
{
    public class TravelServiceFactory : ITravelServiceFactory
    {
        public ITravelService Create()
        {
            return TransparentProxy<ITravelService>.Create(new TravelService());
        }
    }
}
