using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Enums;
using System;

namespace Sat.Recruitment.Api.Business
{
    public class Logic
    {
        public async static Task<User> ApplyUserMoneyLogic(User newUser, string money)
        {
            return await Task.Run(() =>
            {
                if (newUser.UserType == UserType.Normal)
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);

                        //If new user is normal and has more than USD100
                        var gif = decimal.Parse(money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                    if (decimal.Parse(money) < 100)
                    {
                        if (decimal.Parse(money) > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = decimal.Parse(money) * percentage;
                            newUser.Money = newUser.Money + gif;
                        }
                    }
                }

                if (newUser.UserType == UserType.SuperUser)
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = decimal.Parse(money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                }
                if (newUser.UserType == UserType.Premium)
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var gif = decimal.Parse(money) * 2;
                        newUser.Money = newUser.Money + gif;
                    }
                }

                return newUser;
            });
        }
    }
}
