using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Contracts;
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace App.Domain.Services.TurnsManager.TechExamServices;


public class TechExamService : ITechExamService
{
    private readonly ITechExamRepository _techExamRepository;
    private readonly IRejectedRequestService _rejectedRequestService;
    private readonly IConfiguration _configuration;
    public TechExamService(ITechExamRepository techExamRepository, IConfiguration configuration, IRejectedRequestService rejectedRequestService)
    {
        _techExamRepository = techExamRepository;
        _configuration = configuration;
        _rejectedRequestService = rejectedRequestService;
    }


    public List<TechExam>? GetAllExams()
    {
        return _techExamRepository.GetAll();
    }

    public Result AddTechExam(TechExam exam)
    {

        int EvenKhodro = int.Parse(_configuration.GetSection("TurnsSettings:EvenIranKhodro").Value);
        int OddSaipa = int.Parse(_configuration.GetSection("TurnsSettings:OddSaipa").Value);
        int MaxAge = int.Parse(_configuration.GetSection("TurnsSettings:Age").Value);

        var AgeCheck = DateTime.Now.Year - exam.CarAge.Year;

        // بررسی سن خودرو
        if (AgeCheck > MaxAge)
        {
            RejectedRequest rejectedRequest = new RejectedRequest()
            {
                NationalId = exam.NationalId,
                Address = exam.Address,
                PhoneNumber = exam.PhoneNumber,
                PlateNumber = exam.PlateNumber,
                CarAge = exam.CarAge,
                CarName = exam.CarName,
                CompanyName = exam.CompanyName,
                TechExamDate = exam.TechExamDate,
            };

            if (_rejectedRequestService.AddRejectedRequest(rejectedRequest))
            {
                return new Result(false, "Your car age is too high for tech exam!");
            }
            else
            {
                return new Result(false, "Logic error");
            }
        }

        bool EvenDay = exam.TechExamDate.Day % 2 == 0;

        if (EvenDay && exam.CompanyName != CompanyEnum.Irankhodro)
        {
            return new Result(false, "Only IranKhodro vehicles can register on even days.");
        }
        else if (!EvenDay && exam.CompanyName != CompanyEnum.Saipa)
        {
            return new Result(false, "Only Saipa vehicles can register on odd days.");
        }

        var requestCountDate = _techExamRepository.CompanyExamCountInDate(exam.TechExamDate, exam.CompanyName.ToString());
        if (EvenDay && requestCountDate >= EvenKhodro)
        {
            return new Result(false, "Daily IranKhodro's limit exceeded!");
        }
        else if (!EvenDay && requestCountDate >= OddSaipa)
        {
            return new Result(false, "Daily Saipa's limit exceeded!");
        }

        if (_techExamRepository.YearLimit(exam.PlateNumber))
        {
            return new Result(false, "You have already registered a tech exam for this plate number this year!");
        }

        if (_techExamRepository.AddExam(exam))
        {
            return new Result(true, "TechExam added successfully.");
        }

        return new Result(false, "Error at adding Tech Exam!");
    }

    public bool UpdateExamStatus(int examId, StatusEnum newStatus)
    {
        if(_techExamRepository.UpdateStatus(examId, newStatus))
        {
            return true;
        }
        return false;
    }
}
