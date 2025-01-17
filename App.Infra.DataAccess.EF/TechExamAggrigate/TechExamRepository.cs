
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using App.Infra.Data.SqlService.Ef;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.EF.TechExamAggrigate;

public class TechExamRepository : ITechExamRepository
{
    private readonly TurnsDb _context;
    public TechExamRepository(TurnsDb db)
    {
        _context = db;

    }

    public bool AddExam(TechExam Exam)
    {
        try
        {
            _context.TechExams.Add(Exam);
            int Counter = _context.SaveChanges();

            return Counter > 0;
        }
        catch
        {
            return false;
        }
    }

    public List<TechExam>? GetAll()
    {
        return _context.TechExams.ToList();
    }

    public int CompanyExamCountInDate(DateTime requestDate, string coName)
    {
        return _context.TechExams.Where(c => c.TechExamDate == requestDate.Date && c.CompanyName.ToString() == coName).Count();
    }
    public bool YearLimit(string plateNumber)
    {
        var Year = DateTime.Now.Year;
       return _context.TechExams.Any(t => t.PlateNumber == plateNumber && t.TechExamDate.Year ==Year);
    }

    public bool UpdateStatus(int examId, StatusEnum newStatus)
    {
        var exam = _context.TechExams.FirstOrDefault(e => e.Id == examId);
        if (exam != null)
        {
            exam.Status = newStatus;
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
