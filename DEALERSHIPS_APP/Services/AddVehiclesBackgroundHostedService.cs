using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Services
{
    public class AddVehiclesBackgroundHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<AddVehiclesBackgroundHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer? _timer = null;

        public AddVehiclesBackgroundHostedService(ILogger<AddVehiclesBackgroundHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running");

            using (var scope = _serviceProvider.CreateScope())
            {
                using var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<DealershipDbContext>();

                scopedProcessingService.Database.EnsureCreated();
            }            

            _timer = new Timer(AddVehicles, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }


        private async void AddVehicles(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedTransactionService =
                    scope.ServiceProvider
                        .GetRequiredService<IDBTransactionService>();


                try
                {

                    using var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<DealershipDbContext>();

                    
                    await scopedTransactionService.Begin();

                    var vehicle = new Vehicle
                    {
                        Created = DateTime.Now,
                        Crashed = false,
                        DateOfManufacture = DateTime.Now,
                        Mileage = 0,
                        Model = "Mazda",
                        Vin = Guid.NewGuid().ToString().Substring(0, 20),
                    };

                    scopedProcessingService.Vehicles.Add(vehicle);

                    scopedProcessingService.SaveChanges();

                    var ownershipHistory = new OwnershipHistory
                    {
                        VehicleId = vehicle.Id,
                        Created = DateTime.Now,
                        DateOfManufacture = DateTime.Now,
                        DealershipId = 1,
                        FactoryId = 1
                    };

                    scopedProcessingService.OwnershipHistories.Add(ownershipHistory);

                    scopedProcessingService.SaveChanges();

                    await scopedTransactionService.Commit();
                }
                catch (Exception)
                {
                    await scopedTransactionService.Rollback();
                    throw;
                }

            }
        }




        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
