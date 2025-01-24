using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;
using System.Runtime.CompilerServices;

namespace App.Domain.Services.TurnsManager.CarModelServices;

public class CarModelService : ICarModelService
{
    private readonly ICarModelRepository _carModelRepository;
    public CarModelService(ICarModelRepository carModelRepository)
    {
        _carModelRepository = carModelRepository;
    }
    public List<CarModel>? GetAllCarModels()
    {
        return _carModelRepository.GetAll();
    }

    public CarModel? GetCompany(int carId)
    {
       return _carModelRepository.GetCompanyName(carId);
    }

    public Result AddCarModel(CarModel carModel)
    {
        if (_carModelRepository.CheckExist(carModel.Name))
        {
            return new Result(false, "Car already exist");
        }


        if (_carModelRepository.Add(carModel))
        {
            return new Result(true, "Car added successfully");
        }

        return new Result(false, "Logic error at adding car");
    }

    public Result DeleteCarModel(int carId)
    {
        var existCar =_carModelRepository.GetById(carId);

        if (existCar != null)
        {
            if (!_carModelRepository.Delete(carId))
            {
                return new Result(false, "Logic error at deleting car!!!");
            }

            return new Result(true, "Car deleted successfully.");
               
        }
        return new Result(false, "Car dont exist!!!");
    }

    public Result UpdateCarModel(CarModel carModel)
    {
        var existCar = _carModelRepository.GetById(carModel.Id);
        if (existCar == null)
        {
            return new Result(false, "Car does not exist.");
        }

        var CheckName = _carModelRepository.CheckExist(carModel.Name);
                            
        if (CheckName && existCar.Name != carModel.Name )
        {
            return new Result(false, $"The car name '{carModel.Name}' already exists in the database.");
        }

        existCar.Name = carModel.Name;
        existCar.CompanyName = carModel.CompanyName;

        if (!_carModelRepository.Update(existCar))
        {
            return new Result(false, "Logic error at updating the car.");
        }

        return new Result(true, "Car updated successfully.");
    }
    
    public bool CheckCarExist(string carName)
    {
        if (_carModelRepository.CheckExist(carName))
        {
            return true;
        }
        return false;

    }
    public CarModel? GetCarById(int carId)
    {
        return _carModelRepository.GetById(carId);
    }
}
