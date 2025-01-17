using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;

namespace App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts
{
    public interface ICarModelRepository
    {
        
        List<CarModel>? GetAll();
        CarModel? GetCompanyName(int carId);


    }
}
