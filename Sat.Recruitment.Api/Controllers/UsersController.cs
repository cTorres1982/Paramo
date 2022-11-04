using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Model.DTO;
using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Sat.Recruitment.Service.Services;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }
        protected IUsersService Service { get; }
        public UsersController(ILogger<UsersController> logger, IMapper mapper, IUsersService usersService)
        {
            Logger = logger;
            Mapper = mapper;
            Service = usersService;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser([FromBody] UserDto user)
        {
            var userMapped = Mapper.Map<UserEntity>(user);

            try
            {
                return await Service.CreateUser(userMapped);

            }catch(Exception ex)
            {
                Logger.LogError(ex, "Unexpected error");

                return new Result 
                { 
                    IsSuccess = false,
                    Message = "Unexpected error ocurred creating user"
                };
            }
        }        
    }
}
