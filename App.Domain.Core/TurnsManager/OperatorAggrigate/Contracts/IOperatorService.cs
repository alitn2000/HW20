using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts
{
    public interface IOperatorService
    {
        public bool LoginOperator(string userName, string Pass);
        Operator? GetOperatorByName(string userName);
    }
}
