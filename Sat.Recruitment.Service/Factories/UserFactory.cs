using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service.Factories
{
    public abstract class UserFactory : UserEntity
    {
        public abstract void ResolveMoney();

        //Not a super clear requirement
        public void NormalizeEmailAddress()
        {
            //Normalize email
            var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            Email = string.Join("@", aux);
        }
    }
}
