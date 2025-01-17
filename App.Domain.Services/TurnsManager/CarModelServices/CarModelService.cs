using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
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
}
