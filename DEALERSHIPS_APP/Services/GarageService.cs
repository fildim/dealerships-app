using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IGarageService
    {
        Task Create(Garage garage);
        Task<Garage> GetById(int id);
        Task<Garage> GetByPhone(string phone);
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
            var garageCheck = await _garageRepository.GetByPhone(garage.Phone);

            if (garageCheck != null)
            {
                throw new EntityAlreadyExistsException($"Garage with phone = '{garage.Phone}' already exists");
            }

            garage.Created = DateTime.Now;
            await _garageRepository.Create(garage);
        }


        public async Task<Garage> GetById(int id)
        {
            var garage = await _garageRepository.GetById(id);

            if (garage == null)
            {
                throw new EntityNotFoundException($"Garage with id = '{id}' not found");
            }

            return garage;
        }

        public async Task<Garage> GetByPhone(string phone)
        {
            var garage = await _garageRepository.GetByPhone(phone);

            if (garage == null)
            {
                throw new EntityNotFoundException($"Garage with phone = '{phone}' not found");
            }

            return garage;
        }



    }
}
