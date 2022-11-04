using AutoMapper;
using Moq;
using Sat.Recruitment.Api.Mappings;
using Sat.Recruitment.DataAccess;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Service.Services;
using Xunit;
using UserType = Sat.Recruitment.Model.Entities.UserEntityType;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserServiceTests
    {
        protected IUsersService usersService;
        protected IMapper mapper;
        protected Mock<IUsersRepository> usersRepository;

        public UserServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            mapper = config.CreateMapper();

            usersRepository = new Mock<IUsersRepository>();
            usersService = new UsersService(usersRepository.Object, mapper);
        }

        [Fact]
        public async void CreateUser_ShouldWork()
        {
            var newUser = new UserEntity
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            usersRepository.Setup(_ => _.CheckForDuplicates(It.IsAny<UserEntity>())).Returns(false);
            usersRepository.Setup(_ => _.SaveUser(It.IsAny<UserEntity>())).Returns(newUser);

            var result = await usersService.CreateUser(newUser);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Message);
        }

        [Fact]
        public async void CreateUser_ShouldFailbyUserDuplication()
        {

            var newUser = new UserEntity
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            usersRepository.Setup(_ => _.CheckForDuplicates(It.IsAny<UserEntity>())).Returns(true);

            var result = await usersService.CreateUser(newUser);

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Message);
        }
    }
}
