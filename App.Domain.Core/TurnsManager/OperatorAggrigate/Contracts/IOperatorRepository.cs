using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts;

public interface IOperatorRepository
{
    bool LogIn(string userName, string password);
    Operator? GetOperator(string userName);
}
