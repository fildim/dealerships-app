using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IGarageService
    {
        Task Create(Garage garage);
    }


    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;

        public GarageService(IGarageRepository repository)
        {
            this._garageRepository = repository;
        }



        public async Task Create(Garage garage)
        {
            garage.Created = DateTime.Now;
            await _garageRepository.Create(garage);
        }
    }
}
