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
    public OperatorController(IOperatorAppService operatorAppService, ITechExamAppService techExamAppService)
    {
        _operatorAppService = operatorAppService;
        _techExamAppService = techExamAppService;
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
        return View();
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
    
}
