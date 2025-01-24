
using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.ResultAggrigate;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using Microsoft.AspNetCore.Mvc;
using MVCApp.EndPoint.Models;

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
        TempData["Cars"] = Cars;
        return View();
    }

    [HttpPost]
    public IActionResult AddExam(AddExamViewModel examViewModel )
    {
        var CarModel = _carModelAppService.GetCompany(examViewModel.carId);
        string? companyName =CarModel.CompanyName;
        string carName = CarModel.Name;
        var companyNameEnum = (CompanyEnum)Enum.Parse(typeof(CompanyEnum), companyName, true);

        TechExam exam = new TechExam()
        {
            NationalId = examViewModel.nationalId,
            PhoneNumber = examViewModel.phoneNumber,
            Address = examViewModel.Adress,
            PlateNumber = examViewModel.plateNumber,
            CarAge = examViewModel.carAge,
            TechExamDate = examViewModel.examDate,
            CompanyName = companyNameEnum,
            CarName = carName, 
        };

         Result result = _techExamAppService.AddTechExam(exam);

        if(!ModelState.IsValid)
        {
            //ViewBag.Message = result.Message;
            //ViewBag.NationalId = examViewModel.nationalId;
            //ViewBag.PhoneNumber = examViewModel.phoneNumber;
            //ViewBag.Address = examViewModel.Adress;
            //ViewBag.PlateNumber = examViewModel.plateNumber;
            //ViewBag.CarAge = examViewModel.carAge.ToString("yyyy-MM-dd");
            //ViewBag.ExamDate = examViewModel.examDate.ToString("yyyy-MM-dd");
            //ViewBag.CarId = examViewModel.carId;
            return View(examViewModel);
        }
        ViewBag.Message ="ExamAdded Sucsessfully";
        return RedirectToAction("AddExam");
    }
}
