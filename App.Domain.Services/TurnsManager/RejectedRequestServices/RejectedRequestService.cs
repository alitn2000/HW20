using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Contracts;
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;
using App.Domain.Core.TurnsManager.RejectedRequestsAggrigate.Contracts;

namespace App.Domain.Services.TurnsManager.RejectedRequestServices;

public class RejectedRequestService : IRejectedRequestService
{
    private readonly IRejectedRequestRepository _rejectedRequestRepository;
    public RejectedRequestService(IRejectedRequestRepository rejectedRequestRepository)
    {
        _rejectedRequestRepository = rejectedRequestRepository;
    }
    public bool AddRejectedRequest(RejectedRequest request)
    {
        if (_rejectedRequestRepository.AddRejectedRequest(request))
        {
            return true;
        }
        return false;
    }

}
