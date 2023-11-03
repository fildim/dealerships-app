using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Services
{
    public class DBInitializer
    {
        private readonly DealershipDbContext _dbContext;

        public DBInitializer(DealershipDbContext dbContext)
        {
            this._dbContext = dbContext;
        }



        public void Initialize()
        {
            if (_dbContext.Factories.Count() != 0) return;

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
                    Vin = "1a"
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Mazda",
                    Vin = "2b"
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Fiat",
                    Vin = "3c"
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "Ford",
                    Vin = "4d"
                },
                new Vehicle
                {
                    Created = DateTime.Now,
                    Crashed = false,
                    DateOfManufacture = DateTime.Now,
                    Mileage = 0,
                    Model = "BMW",
                    Vin = "5e"
                }
            };
            _dbContext.Vehicles.AddRange(vehicles);

            _dbContext.SaveChanges();

            var ownership_histories = new List<OwnershipHistory>
            {
                new OwnershipHistory
                {
                    
                    VehicleId = 1,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = 1,
                    FactoryId = 1
                },
                new OwnershipHistory
                {
                    VehicleId = 2,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = 2,
                    FactoryId = 2
                },
                new OwnershipHistory
                {
                    VehicleId = 3,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = 3,
                    FactoryId = 3
                },
                new OwnershipHistory
                {
                    VehicleId = 4,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = 4,
                    FactoryId = 4
                },
                new OwnershipHistory
                {
                    VehicleId = 5,
                    Created = DateTime.Now,
                    DateOfManufacture = DateTime.Now,
                    DealershipId = 5,
                    FactoryId = 5
                }
            };
            _dbContext.OwnershipHistories.AddRange(ownership_histories);

            _dbContext.SaveChanges();
            

            //        var ownerships = new List<Ownership>
            //{
            //    new Ownership
            //    {
            //        Id = 1,
            //        Created = DateTime.Now,
            //        OwnerId = 1,
            //        VehicleId = 1
            //    },
            //    new Ownership
            //    {
            //        Id = 2,
            //        Created = DateTime.Now,
            //        OwnerId = 2,
            //        VehicleId = 2
            //    },
            //    new Ownership
            //    {
            //        Id = 3,
            //        Created = DateTime.Now,
            //        OwnerId = 3,
            //        VehicleId = 3
            //    },
            //    new Ownership
            //    {
            //        Id = 4,
            //        Created = DateTime.Now,
            //        OwnerId = 4,
            //        VehicleId = 4
            //    },
            //    new Ownership
            //    {
            //        Id = 5,
            //        Created = DateTime.Now,
            //        OwnerId = 5,    
            //        VehicleId = 5
            //    }
            //};
        }
    }
}
