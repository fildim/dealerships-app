using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IOwnerService
    {
        Task Create(Owner owner);
        Task<Owner> GetById(int id);
        Task<Owner> GetByPhone(string phone);
    }



    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IOwnershipRepository _ownershipRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public OwnerService(IOwnerRepository repository, IOwnershipRepository ownershipRepository, IVehicleRepository vehicleRepository)
        {
            this._ownerRepository = repository;
            _ownershipRepository = ownershipRepository;
            _vehicleRepository = vehicleRepository;
        }




        public async Task Create(Owner owner)
        {
            var ownerCheck = await _ownerRepository.GetByPhone(owner.Phone);

            if (ownerCheck != null)
            {
                throw new EntityAlreadyExistsException($"Owner with phone = '{owner.Phone}' already exists");
            }

            owner.Created = DateTime.Now;
            await _ownerRepository.Create(owner);
        }


        public async Task<Owner> GetById(int id)
        {
            var owner = await _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new EntityNotFoundException($"Owner with id = '{id}' not found");
            }

            return owner;
        }

        public async Task<Owner> GetByPhone(string phone)
        {
            var owner = await _ownerRepository.GetByPhone(phone);

            if (owner == null)
            {
                throw new EntityNotFoundException($"Owner with phone = '{phone}' not found");
            }

            return owner;
        }

        //public async Task<> BindVehicle(int id)




    }
}
