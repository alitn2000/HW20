using App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.OperatorAggrigate;

public class OperatorAppService : IOperatorAppService
{
    private readonly IOperatorService _operatorService;
    public OperatorAppService(IOperatorService operatorService)
    {
        _operatorService = operatorService;
    }

    public Operator? GetOperatorByName(string userName)
    {
        return _operatorService.GetOperatorByName(userName);
    }

    public bool LoginOperator(string userName, string Pass)
    {
        return _operatorService.LoginOperator(userName, Pass);
    }


}
