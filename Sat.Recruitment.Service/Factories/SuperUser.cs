using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service.Factories
{
    public class SuperUser: UserFactory
    {
        public override void ResolveMoney()
        {
            if (Money > 100)
            {
                var percentage = 0.20m; //Convert.ToDecimal(0.20);
                var gif = Money * percentage;
                Money = Money + gif;
            }
        }
    }
}
