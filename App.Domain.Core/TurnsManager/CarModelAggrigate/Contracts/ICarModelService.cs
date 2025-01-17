﻿using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts
{
    public interface ICarModelService
    {
        CarModel? GetCompany(int carId);
        List<CarModel>? GetAllCarModels();
    }
}
