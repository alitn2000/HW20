using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;

public interface ICarModelAppService
{
    List<CarModel>? GetAllCarModels();
    CarModel? GetCompany(int carId);
    Result AddCarModel(CarModel carModel);
    Result DeleteCarModel(int carId);
    Result UpdateCarModel(CarModel carModel);
    bool CheckCarExist(string carName);
    CarModel? GetCarById(int carId);
}
