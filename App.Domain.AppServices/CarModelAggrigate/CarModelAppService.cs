using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;

namespace App.Domain.AppServices.CarModelAggrigate;

public class CarModelAppService : ICarModelAppService
{
    private readonly ICarModelService _carModelService;
    public CarModelAppService(ICarModelService carModelService)
    {
        _carModelService = carModelService;
    }

    public Result AddCarModel(CarModel carModel)
    {
        return _carModelService.AddCarModel(carModel);
    }

    public bool CheckCarExist(string carName)
    {
        return _carModelService.CheckCarExist(carName);
    }

    public Result DeleteCarModel(int carId)
    {
        return _carModelService.DeleteCarModel(carId);
    }

    public List<CarModel>? GetAllCarModels()
    {
        return _carModelService.GetAllCarModels();
    }

    public CarModel? GetCarById(int carId)
    {
        return _carModelService.GetCarById(carId);
    }

    public CarModel? GetCompany(int carId)
    {
        return _carModelService.GetCompany(carId);
    }

    public Result UpdateCarModel(CarModel carModel)
    {
        return _carModelService.UpdateCarModel(carModel);
    }
}
