using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Services
{
    public class DBInitializer
    {
        private readonly DealershipDbContext _dbContext;
        private readonly IDBTransactionService _dBTransactionService;

        public DBInitializer(DealershipDbContext dbContext, IDBTransactionService dBTransactionService)
        {
            this._dbContext = dbContext;
            _dBTransactionService = dBTransactionService;
        }



        public async Task Initialize()
        {
            //_dbContext.Database.EnsureCreated();

            if (_dbContext.Factories.Count() != 0) return;

            await _dBTransactionService.Begin();

            try
            {

                var factories = new List<Factory>
            {
                new Factory()
                {

                    Created = DateTime.Now,
                    Location = "Italy"
                },
                new Factory()
                {

                    Created = DateTime.Now,
                    Location = "Spain"
                },
                new Factory()
                {

                    Created = DateTime.Now,
                    Location = "Greece"
                },
                new Factory()
                {

                    Created = DateTime.Now,
                    Location = "Germany"
                },
                new Factory()
                {

                    Created = DateTime.Now,
                    Location = "England"
                }
            };
                _dbContext.Factories.AddRange(factories);

                var dealerships = new List<Dealership>
            {
                new Dealership
                {

                    Created = DateTime.Now,
                    Name = "Mazda dealership",
                    Address = "Athens",
                    Phone = "210000111"
                },
                new Dealership
                {
                    Created = DateTime.Now,
                    Name = "Ford dealership",
                    Address = "Thessaloniki",
                    Phone = "2101111000"
                },
                new Dealership
                {
                    Created = DateTime.Now,
                    Name = "Fiat dealership",
                    Address = "Larissa",
                    Phone = "2102222111"
                },
                new Dealership
                {
                    Created = DateTime.Now,
                    Name = "BMW dealership",
                    Address = "Volos",
                    Phone = "2101111222"
                },
                new Dealership
                {
                    Created = DateTime.Now,
                    Name = "Jeep dealership",
                    Address = "Patra",
                    Phone = "2103333111"
                }
            };
                _dbContext.Dealerships.AddRange(dealerships);

                var vehicles = new List<Vehicle>
            {
                new Vehicle
                {

                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Jeep",
                    Vin = Guid.NewGuid().ToString().Substring(0, 20)
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Mazda",
                    Vin = Guid.NewGuid().ToString().Substring(0, 20)
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Fiat",
                    Vin = Guid.NewGuid().ToString().Substring(0, 20)
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Ford",
                    Vin = Guid.NewGuid().ToString().Substring(0, 20)
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "BMW",
                    Vin = Guid.NewGuid().ToString().Substring(0, 20)
                }
            };
                _dbContext.Vehicles.AddRange(vehicles);

                _dbContext.SaveChanges();

                var ownership_histories = new List<OwnershipHistory>
            {
                new OwnershipHistory
                {

                    VehicleId = vehicles[0].Id,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = dealerships[0].Id,
                    FactoryId = factories[0].Id
                },
                new OwnershipHistory
                {
                    VehicleId = vehicles[1].Id,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = dealerships[1].Id,
                    FactoryId = factories[1].Id
                },
                new OwnershipHistory
                {
                    VehicleId = vehicles[2].Id,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = dealerships[2].Id,
                    FactoryId = factories[2].Id
                },
                new OwnershipHistory
                {
                    VehicleId = vehicles[3].Id,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = dealerships[3].Id,
                    FactoryId = factories[3].Id
                },
                new OwnershipHistory
                {
                    VehicleId = vehicles[4].Id,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = dealerships[4].Id,
                    FactoryId = factories[4].Id
                }
            };
                _dbContext.OwnershipHistories.AddRange(ownership_histories);

                _dbContext.SaveChanges();

                await _dBTransactionService.Commit();

            }
            catch (Exception)
            {
                await _dBTransactionService.Rollback();
                throw;
            }

        }
    }
}
