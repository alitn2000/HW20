using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using MVCApp.EndPoint.Validations;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoint.Models;

public class AddExamViewModel
{
    [Display(Name ="National Id")]
    [Required(ErrorMessage ="National is required")]
    [StringLength(10)]
    public string nationalId { get; set; }

    [Display(Name = "Phone number")]
    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(11,ErrorMessage ="Phone number format error")]
    [RegularExpression(@"^09\d{9}$",ErrorMessage ="Phone number from is invalid")]
    public string phoneNumber { get; set; }

    [Display(Name = "Adress")]
    [Required(ErrorMessage = " Adress is required")]
    [StringLength(200, ErrorMessage = "Phone number format error")]

    public string Adress { get; set; }

    [Display(Name = "Plate number")]
    [Required(ErrorMessage = " Plate number is required")]
    public string plateNumber { get; set; }

    [Display(Name = " Car age")]
    [Required(ErrorMessage = " Car age is required")]
    public DateTime carAge { get; set; }

    [Display(Name = " Exam date")]
    [Required(ErrorMessage = " Exam date is required")]
    [DateValidation(ErrorMessage = "Date must be after today")]
    public DateTime examDate { get; set; }

    [Display(Name = " Car model")]
    [Required(ErrorMessage = " Car model is required")]
    public int carId { get; set; }
}
