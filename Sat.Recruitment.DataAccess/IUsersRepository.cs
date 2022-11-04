using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.DataAccess
{
    public interface IUsersRepository
    {
        List<UserEntity> GetUserEntities();
        bool CheckForDuplicates(UserEntity userEntity);
        UserEntity SaveUser(UserEntity userEntity);
    }
}
