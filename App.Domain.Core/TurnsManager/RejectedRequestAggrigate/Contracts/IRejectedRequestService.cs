using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;
using App.Domain.Core.TurnsManager.RejectedRequestsAggrigate.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Contracts;


public interface IRejectedRequestService
{
    bool AddRejectedRequest(RejectedRequest request);
}
