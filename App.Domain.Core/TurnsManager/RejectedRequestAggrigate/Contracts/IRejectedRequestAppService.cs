using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Contracts
{
    public interface IRejectedRequestAppService
    {
        bool AddRejectedRequest(RejectedRequest request);
    }
}
