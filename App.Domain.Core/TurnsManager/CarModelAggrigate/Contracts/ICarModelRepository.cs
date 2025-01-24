using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;

namespace App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts
{
    public interface ICarModelRepository
    {
        
        List<CarModel>? GetAll();
        CarModel? GetCompanyName(int carId);
        bool Add(CarModel carModel);
        bool CheckExist(string carName);
        bool Delete(int carId);
        bool Update(CarModel carModel);
        CarModel? GetByName(string carName);
        CarModel? GetById(int carId);

    }
}
