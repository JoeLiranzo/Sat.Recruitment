using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.Models;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Validations
{
    public static class UserValidation
    {
        //Validate errors
        public async static Task<string> ValidateUserErrors(string name, string email, string address, string phone, string userType)
        {
            string errors = "";

            await Task.Run(() =>
            {
                if (name == null)
                    //Validate if Name is null
                    errors = "The name is required";
                if (email == null)
                    //Validate if Email is null
                    errors = errors + " The email is required";
                if (address == null)
                    //Validate if Address is null
                    errors = errors + " The address is required";
                if (phone == null)
                    //Validate if Phone is null
                    errors = errors + " The phone is required";
                if (!Enum.TryParse(userType, out UserType oUserType))
                    errors = errors + "Invalid UserType";
            });

            return errors;
        }
    }
}
