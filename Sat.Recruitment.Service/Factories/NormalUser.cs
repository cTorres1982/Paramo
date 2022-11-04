using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Sat.Recruitment.Service.Factories
{
    public class NormalUser : UserFactory
    {
        public override void ResolveMoney()
        {
            decimal percentage = 0;
            if (Money > 100)
            {
                percentage = 0.12m; //Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
            }else if (Money < 100 && Money > 10)
            {
                percentage = 0.8m;// Convert.ToDecimal(0.8);
            }

            var gif = Money * percentage;

            Money = Money + gif;
        }
    }
}
