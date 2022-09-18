using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.Validations;
using Sat.Recruitment.Api.Data;

namespace Sat.Recruitment.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            //BEGIN ERRORS REGION
            var errors = await UserValidation.ValidateUserErrors(name, email, address, phone, userType);
            if (errors != null && errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };
            //END ERRORS REGION

            //BEGIN SETTING USER
            var newUser = new User
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
                UserType = (UserType)Enum.Parse(typeof(UserType), userType),
                Money = decimal.Parse(money)
            };
            //END SETTING USER

            //BEGIN USER LOGIC
            newUser = await Business.Logic.ApplyUserMoneyLogic(newUser, money);
            //END USER LOGIC

            //Saving new User on File
            return await FileData.SaveUserData(newUser);
        }
    }
}
