using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CarModelAggrigate;

public class CarModelAppService : ICarModelAppService
{
    private readonly ICarModelService _carModelService;
    public CarModelAppService(ICarModelService carModelService)
    {
        _carModelService = carModelService;
    }
    public List<CarModel>? GetAllCarModels()
    {
        return _carModelService.GetAllCarModels();
    }

    public CarModel? GetCompany(int carId)
    {
       return _carModelService.GetCompany(carId);
    }
}
