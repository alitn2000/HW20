using App.Domain.Core.TurnsManager.CarModelAggrigate.Contracts;
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Contracts;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using Microsoft.AspNetCore.Mvc;
using MVCApp.EndPoint.Models;

namespace MVCApp.EndPoint.Controllers;

public class OperatorController : Controller
{
    private readonly IOperatorAppService _operatorAppService;
    private readonly ITechExamAppService _techExamAppService;
    private readonly ICarModelAppService _carModelAppService;
    public OperatorController(
        IOperatorAppService operatorAppService,
        ITechExamAppService techExamAppService,
        ICarModelAppService carModelAppService)
    {
        _operatorAppService = operatorAppService;
        _techExamAppService = techExamAppService;
        _carModelAppService = carModelAppService;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string userName, string Pass)
    {
        if (_operatorAppService.LoginOperator(userName, Pass))
        {
            var LoginOp = _operatorAppService.GetOperatorByName(userName);
            OnlineOperator.Online = new Operator
            {
                Id = LoginOp.Id,
                UserName = userName,
                Password = Pass
            };
            return RedirectToAction("TechExamLists", "Operator");
        }
        ViewBag.LogInError = "Username or password is incorrect";
        return View("Login");
    }
    [HttpPost]
    public IActionResult Logout()
    {
        OnlineOperator.Online = null;
        return RedirectToAction("Login", "Operator");
    }
    public IActionResult TechExamLists()
    {
        if (OnlineOperator.Online == null)
        {
            return RedirectToAction("Login", "Operator");
        }
        var Exams = _techExamAppService.GetAllExams()
        .OrderBy(e => e.TechExamDate) 
        .ThenBy(e => e.Status)
        .ToList();
        return View(Exams);
    }

    [HttpGet]
    public IActionResult UpdateStatus()
    {
        if (OnlineOperator.Online == null)
        {
          
            return RedirectToAction("Login", "Operator");
        }
        var Exams = _techExamAppService.GetAllExams();
        return View(Exams);
    }

    [HttpPost]
    public IActionResult UpdateStatus(int id, string newStatus)
    {
        StatusEnum status;

        if (newStatus == "Accept")
        {
            status = StatusEnum.Accepted;
        }
        else if (newStatus == "Reject")
        {
            status = StatusEnum.Rejected;
        }
        else
        {
            status = StatusEnum.Pending;
        }
        _techExamAppService.UpdateExamStatus(id, status);
        ViewBag.Change = "Status Changed";
        return RedirectToAction("UpdateStatus");
    }

    public IActionResult CarModelList()
    {
        if (OnlineOperator.Online == null)
        {

            return RedirectToAction("Login", "Operator");
        }
        var Cars = _carModelAppService.GetAllCarModels();
        return View(Cars);
    }

    [HttpGet]
    public IActionResult AddCarModel()
    {
        if (OnlineOperator.Online == null)
        {

            return RedirectToAction("Login", "Operator");
        }
        return View();
    }

    [HttpPost]
    public IActionResult AddCarModel(AddCarModelViewModel carModelView)
    {

        if (!ModelState.IsValid)
        {
            return View(carModelView);
        }
        if (_carModelAppService.CheckCarExist(carModelView.Name))
        {
            TempData["addCarError"] = "Car is already exist";
            return View(carModelView);
        }
        else
        {
            CarModel carModel = new CarModel()
            {
                CompanyName = carModelView.CompanyName,
                Name = carModelView.Name
            };
            TempData["Message"] = "Car model added Sucsessfully";
            _carModelAppService.AddCarModel(carModel);
            return RedirectToAction("AddCarModel");
        }

       
    }

    public IActionResult Delete(int id)
    {
       var result = _carModelAppService.DeleteCarModel(id);
        TempData["DeleteMessage"] = result.Message;
        return RedirectToAction("CarModelList");
        
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var car = _carModelAppService.GetCarById(id);
        if (car == null)
        {
            TempData["UpdateMessage"] = "Car not found.";
            return RedirectToAction("CarModelList");
        }

        return View(car);
    }

    [HttpPost]
    public IActionResult Update(CarModel carModel)
    {
        var result =_carModelAppService.UpdateCarModel(carModel);

        TempData["ResultMessage"] = result.Message;
        return RedirectToAction("Update", new { id = carModel.Id });
    }
}
