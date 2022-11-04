using Sat.Recruitment.Model.DTO;
using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public interface IUsersService
    {
        Task<Result> CreateUser(UserEntity user);
    }
}
