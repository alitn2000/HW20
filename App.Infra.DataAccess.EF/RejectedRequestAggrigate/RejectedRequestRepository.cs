using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;
using App.Domain.Core.TurnsManager.RejectedRequestsAggrigate.Contracts;
using App.Domain.Core.TurnsManager.ResultAggrigate;
using App.Infra.Data.SqlService.Ef;

namespace App.Infra.DataAccess.EF.RejectedRequestAggrigate;

public class RejectedRequestRepository : IRejectedRequestRepository
{
    private readonly TurnsDb _context;
    public RejectedRequestRepository(TurnsDb db)
    {
        _context = db;
    }


    public bool AddRejectedRequest(RejectedRequest reject)
    {
        try
        {
            _context.RejectedRequests.Add(reject);
            int Counter = _context.SaveChanges();

            return Counter > 0;
        }
        catch
        {
            return false;
        }
    }

}
