using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service.Factories
{
    public class PremiumUser: UserFactory
    {
        public override void ResolveMoney()
        {
            if (Money > 100)
            {
                var gif = Money * 2;
                Money = Money + gif;
            }
        }
    }
}
