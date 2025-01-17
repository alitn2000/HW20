using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Contracts;
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;

namespace App.Domain.AppServices.RejectedRequestAggrigate;

public class RejectedRequestAppService : IRejectedRequestAppService
{
    private readonly IRejectedRequestService _rejectedRequestService;
    public RejectedRequestAppService(IRejectedRequestService rejectedRequestService)
    {
        _rejectedRequestService = rejectedRequestService;
    }
    public bool AddRejectedRequest(RejectedRequest request)
    {
       return _rejectedRequestService.AddRejectedRequest(request);
    }
}
