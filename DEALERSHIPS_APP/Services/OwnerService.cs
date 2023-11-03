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

        public OwnerService(IOwnerRepository repository)
        {
            this._ownerRepository = repository;
        }




        public async Task Create(Owner owner)
        {
            var owner_check = await _ownerRepository.GetByPhone(owner.Phone);

            if (owner_check != null)
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




    }
}
