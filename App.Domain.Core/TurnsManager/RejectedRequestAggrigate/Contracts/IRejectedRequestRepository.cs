
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;

namespace App.Domain.Core.TurnsManager.RejectedRequestsAggrigate.Contracts 
{
    public interface IRejectedRequestRepository
    {
        bool AddRejectedRequest(RejectedRequest reject);
    }
}