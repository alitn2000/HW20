using App.Domain.Core.TurnsManager.ResultAggrigate;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts
{
    public interface ITechExamService
    {
        List<TechExam>? GetAllExams();
        Result AddTechExam(TechExam exam);
        bool UpdateExamStatus(int examId, StatusEnum newStatus);
    }
}
