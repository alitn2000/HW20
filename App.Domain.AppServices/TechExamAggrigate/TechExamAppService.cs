using App.Domain.Core.TurnsManager.ResultAggrigate;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;

namespace App.Domain.AppServices.TechExamAggrigate;

public class TechExamAppService : ITechExamAppService
{
    private readonly ITechExamService _techExamService;
    public TechExamAppService(ITechExamService techExamService)
    {
        _techExamService = techExamService;
    }

    public Result AddTechExam(TechExam exam)
    {
        return _techExamService.AddTechExam(exam);
    }

    public List<TechExam>? GetAllExams()
    {
        return _techExamService.GetAllExams();
    }

    public bool UpdateExamStatus(int examId, StatusEnum newStatus)
    {
       return _techExamService.UpdateExamStatus(examId, newStatus);
    }
}
