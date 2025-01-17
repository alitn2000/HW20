using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;

namespace App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;

public class RejectedRequest
{
    public int Id { get; set; }
    public string NationalId { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public CompanyEnum CompanyName { get; set; }
    public string CarName { get; set; }
    public string PlateNumber { get; set; }
    public DateTime CarAge { get; set; }
    public DateTime TechExamDate { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Rejected;
}
