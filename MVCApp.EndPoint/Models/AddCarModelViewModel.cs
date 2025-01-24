using App.Domain.Core.TurnsManager.TechExamAggrigate.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoint.Models;

public class AddCarModelViewModel
{
    [Display(Name = "Name")]
    [Required(ErrorMessage ="Car model is required")]
    [StringLength(20,ErrorMessage ="Length error")]
    public string Name { get; set; }

    [Display(Name = "Company")]
    [Required(ErrorMessage = "Company is required")]
    [StringLength(30, ErrorMessage = "Length error")]
    public string CompanyName { get; set; }
}
