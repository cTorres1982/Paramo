using AutoMapper;
using Sat.Recruitment.DataAccess;
using Sat.Recruitment.Model.DTO;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Service.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository Repository;
        private readonly IMapper Mapper;

        public UsersService(IUsersRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<Result> CreateUser(UserEntity userEntity)
        {
            UserFactory user = ResolveUserType(userEntity.UserType);

            Mapper.Map(userEntity, user);

            user.ResolveMoney();
            user.NormalizeEmailAddress();

            var isDuplicate = Repository.CheckForDuplicates(user);

            if (isDuplicate)
            {
                return new Result() { Message = "The user is duplicated", IsSuccess = false };
            }
            else
            {
                Repository.SaveUser(userEntity);
                return new Result() { IsSuccess = true, Message = "User Created" };
            }
        }

        private UserFactory ResolveUserType(UserEntityType type)
        {
            switch (type)
            {
                case UserEntityType.Normal:
                    return new NormalUser();
                case UserEntityType.SuperUser:
                    return new SuperUser();
                case UserEntityType.Premium:
                    return new PremiumUser();
                default:
                    throw new Exception("Unhandled user type");
            }
        }
    }
}
