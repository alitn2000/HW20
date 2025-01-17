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

    public List<CarModel>? GetAll()
    {
       return _context.CarModels.ToList();
    }
    public CarModel? GetCompanyName(int carId)
    {
       var Car = _context.CarModels.FirstOrDefault(c => c.Id == carId);
        return Car;
    }

    public bool YearLimit(string plateNumber)
    {
        var Year = DateTime.Now.Year;
        return _context.TechExams.Any(t => t.PlateNumber == plateNumber);

    }
}
