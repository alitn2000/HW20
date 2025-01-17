
using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.EndPoint.Controllers;

public class TechExamController : Controller
{
    private readonly ICarModelAppService _carModelAppService;
    private readonly ITechExamAppService _techExamAppService;
    public TechExamController(ICarModelAppService carModelAppService, ITechExamAppService techExamAppService)
    {
        _carModelAppService = carModelAppService;
        _techExamAppService = techExamAppService;
    }
    [HttpGet]
    public IActionResult AddExam()
    {
       var Cars =  _carModelAppService.GetAllCarModels();

        return View(Cars);
    }

    [HttpPost]
    public IActionResult AddExam(string nationalId, string phoneNumber, string Adress,string plateNumber, DateTime carAge,DateTime examDate, int carId )
    {
        var CarModel = _carModelAppService.GetCompany(carId);
        string? companyName =CarModel.CompanyName;
        string carName = CarModel.Name;
        var companyNameEnum = (CompanyEnum)Enum.Parse(typeof(CompanyEnum), companyName, true);

        TechExam exam = new TechExam()
        {
            NationalId = nationalId,
            PhoneNumber = phoneNumber,
            Address = Adress,
            PlateNumber = plateNumber,
            CarAge = carAge,
            TechExamDate = examDate,
            CompanyName = companyNameEnum,
            CarName = carName, 
        };

         Result result = _techExamAppService.AddTechExam(exam);

        if(result.Flag == false)
        {
            ViewBag.Message = result.Message;
            ViewBag.NationalId = nationalId;
            ViewBag.PhoneNumber = phoneNumber;
            ViewBag.Address = Adress;
            ViewBag.PlateNumber = plateNumber;
            ViewBag.CarAge = carAge.ToString("yyyy-MM-dd");
            ViewBag.ExamDate = examDate.ToString("yyyy-MM-dd");
            ViewBag.CarId = carId;
            var Cars = _carModelAppService.GetAllCarModels();
            return View(Cars);
        }
        ViewBag.Message ="ExamAdded Sucsessfully";
        return RedirectToAction("AddExam");
    }
}
