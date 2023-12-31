﻿using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IAppointmentRepository
    {
        Task Create (Appointment appointment);
        Task<Appointment?> Get(int vehicleId, DateTime dateOfArrival);
        Task<List<Appointment>> GetAllByGarageId(int garageId);
        Task<List<Appointment>> GetAllByGarageIdForOwnerId(int garageId, int ownerId);
        Task<List<Appointment>> GetAllByOwnerId(int ownerId);
        Task<Appointment?> GetById(int id);
        Task Update(Appointment appointment);
    }


    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DealershipDbContext _dbContext;

        public AppointmentRepository(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public async Task Create(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Appointment?> GetById(int id)
        {
            return await _dbContext.Appointments.Include(x => x.Owner).Include(x => x.Vehicle).Include(x => x.Garage).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Appointment?> Get(int vehicleId, DateTime dateOfArrival)
        {
            return await _dbContext.Appointments.Include(x => x.Owner).Include(x => x.Vehicle).Include(x => x.Garage).SingleOrDefaultAsync(x => x.VehicleId == vehicleId && x.DateOfArrival == dateOfArrival);
        }

        

        public async Task<List<Appointment>> GetAllByOwnerId(int ownerId)
        {
            return await _dbContext.Appointments.Where(x => x.OwnerId == ownerId).Include(x => x.Vehicle).Include(x => x.Garage).ToListAsync();
        }

        public async Task<List<Appointment>> GetAllByGarageId(int garageId)
        {
            return await _dbContext.Appointments.Where(x => x.GarageId == garageId).Include(x => x.Owner).Include(x => x.Vehicle).ToListAsync();
        }

        public async Task<List<Appointment>> GetAllByGarageIdForOwnerId(int garageId, int ownerId)
        {
            return await _dbContext.Appointments.Where(x => x.GarageId == garageId &&  x.OwnerId == ownerId).Include(x => x.Owner).Include(x => x.Vehicle).ToListAsync();
        }

        public async Task Update(Appointment appointment)
        {
            _dbContext.Appointments.Update(appointment);
            await _dbContext.SaveChangesAsync();
        }


    }
}
