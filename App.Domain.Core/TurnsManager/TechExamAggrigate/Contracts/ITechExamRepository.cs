
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
namespace App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;

public interface ITechExamRepository
{
    bool AddExam(TechExam Exam);
    List<TechExam>? GetAll();
    int CompanyExamCountInDate(DateTime requestDate, string coName);
    bool YearLimit(string plateNumber);
    bool UpdateStatus(int examId, StatusEnum newStatus);
}
