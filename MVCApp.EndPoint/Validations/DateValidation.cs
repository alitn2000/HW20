using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoint.Validations
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}
