using App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.TurnsManager.OperatorServices;


public class OperatorService : IOperatorService
{
    private readonly IOperatorRepository _operatorRepository;
    public OperatorService(IOperatorRepository operatorRepository)
    {
        _operatorRepository = operatorRepository;
    }

    public bool LoginOperator(string userName, string Pass)
    {
        if(_operatorRepository.LogIn(userName, Pass))
        {
            return true;
        }
        return false;
    }
    public Operator? GetOperatorByName(string userName)
    {
       return _operatorRepository.GetOperator(userName);
    }

}
