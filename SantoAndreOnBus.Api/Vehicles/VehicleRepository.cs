using Microsoft.EntityFrameworkCore;
using SantoAndreOnBus.Api.Infrastructure;

namespace SantoAndreOnBus.Api.Vehicles;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetAllAsync();
    Task<Vehicle?> GetAsync(int id);
    Task<int> SaveAsync(Vehicle vehicle);
    Task<int> UpdateAsync(Vehicle vehicle);
    Task<int> DeleteAsync(Vehicle vehicle);
}

public class VehicleRepository : IVehicleRepository
{
    private readonly DatabaseContext _db;

    public VehicleRepository(DatabaseContext db) => _db = db;

    public Task<List<Vehicle>> GetAllAsync() =>
        _db.Vehicles.OrderBy(v => v.Id).ToListAsync();

    public Task<Vehicle?> GetAsync(int id) =>
        _db.Vehicles.FirstOrDefaultAsync(x => x.Id == id); 

    public Task<int> SaveAsync(Vehicle vehicle)
    {
        _db.Vehicles.Add(vehicle);
        return _db.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(Vehicle vehicle)
    {
        _db.Entry(vehicle).State = EntityState.Modified;
        _db.Update(vehicle);

        return _db.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(Vehicle vehicle)
    {
        _db.Vehicles.Remove(vehicle);
        
        return _db.SaveChangesAsync();
    }
}
