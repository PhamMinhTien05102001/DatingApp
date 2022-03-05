
using System;

namespace DatingApp.API.Extensions
{
    public static class DateTimeExtensions
    { 
        public static int CaculateAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Now;
            var age = today.Year - dateOfBirth.Year;
            if(dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}