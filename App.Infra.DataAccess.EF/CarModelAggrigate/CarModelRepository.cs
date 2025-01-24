using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Infra.Data.SqlService.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EF.CarModelAggrigate;

public class CarModelRepository : ICarModelRepository
{
    private readonly TurnsDb _context;
    public CarModelRepository(TurnsDb db)
    {
        _context = db;

    }

    public bool Add(CarModel carModel)
    {
        try
        {
            _context.CarModels.Add(carModel);
            int Counter = _context.SaveChanges();

            return Counter > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool CheckExist(string carName)
    {
       return _context.CarModels.Any(c => c.Name == carName);
    }

    public bool Delete(int carId)
    {
        try
        {
            var Car = GetById(carId);
            _context.CarModels.Remove(Car);
            int counter = _context.SaveChanges();
            return counter > 0;
        }
        catch
        {
            return false;
        }
    }

    public List<CarModel>? GetAll()
    {
       return _context.CarModels.ToList();
    }

    public CarModel? GetByName(string carName)
    {
       return _context.CarModels.FirstOrDefault(c => c.Name == carName);
    }
    public CarModel? GetById(int carId)
    {
        return _context.CarModels.FirstOrDefault(c => c.Id == carId);
    }

    public CarModel? GetCompanyName(int carId)
    {
       var Car = _context.CarModels.FirstOrDefault(c => c.Id == carId);
        return Car;
    }

    public bool Update(CarModel carModel)
    {
        try
        {
            _context.CarModels.Update(carModel);
            int Counter = _context.SaveChanges();

            return Counter > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool YearLimit(string plateNumber)
    {
        var Year = DateTime.Now.Year;
        return _context.TechExams.Any(t => t.PlateNumber == plateNumber);

    }
}
