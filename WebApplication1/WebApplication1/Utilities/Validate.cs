using WebApplication1.Models;

namespace Utilities;
public static class Validate
{
   
    public static bool  ValidateForm(FormViewModel form)
    {
        var validation = new List<bool>();
        if (form != null)
        {
            validation.Add(ValidateName(form.FirstName));
            validation.Add(ValidateName(form.LastName));
            validation.Add(ValidatePhoneNumber(form.PhoneNumber));
            validation.Add(ValidateCourseCode(form.CourseCode));
            validation.Add(ValidateSex(form.Sex));
            validation.Add(ValidateBirthDate(form.BirthDate));
            if (!validation.Contains(false))
            {
                return true;
            }

        }
        return false;
    }
    private static bool ValidateName(string name)
    {
        if (!string.IsNullOrEmpty(name)) {

            if (name.Length > 2 && name.Length < 31) { 
            
                    return true;
            }
        }
        return false;
    }
    private static bool ValidatePhoneNumber(string phoneNumber) {
        if (!string.IsNullOrEmpty(phoneNumber)) {
            if (phoneNumber.Length == 11 && phoneNumber.StartsWith("09")) { 
            
                return true;
            }
            
        }
        return false ;
    }
    private static bool ValidateCourseCode(string courseCode) {

        if (!string.IsNullOrEmpty(courseCode)) { 
            if(courseCode.Length == 3)
            {
               if (int.TryParse(courseCode, out _))
                {
                    int hundered = courseCode[0] - '0';
                    if (hundered % 2 == 0) {
                        return true ;
                    }

                }
            }
        }
        return false;
    }
    private static bool ValidateSex(string sex) {
        if (!string.IsNullOrEmpty(sex)) {
            if(sex == "Female" || sex == "Male")
            {
                return true;
            }
        }
        return false;
    }
    private static bool ValidateBirthDate(DateOnly date) {
        if (date != null)
        {
            var yearNow = DateTime.Now.Year;
            var birthYear = date.Year;
            var age = yearNow - birthYear;
            if (age > 17) {
                return true;
            }
        }
        return false;
    
    }
}