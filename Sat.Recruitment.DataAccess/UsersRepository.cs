using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sat.Recruitment.DataAccess
{
    public class UsersRepository: IUsersRepository
    {
        private readonly List<UserEntity> _users = new List<UserEntity>();

        public UsersRepository()
        {
            LoadUserEntities();
        }

        public UserEntity SaveUser(UserEntity userEntity)
        {
            //just a mock
            return userEntity;
        }
        public bool CheckForDuplicates(UserEntity userEntity)
        {

            return _users.Count(
                u => u.Email.ToLower() == userEntity.Email.ToLower() 
                || 
                u.Phone == userEntity.Phone
                || 
                (u.Name.ToLower().Trim() == userEntity.Name.ToLower().Trim() && u.Address.ToLower().Trim() == u.Address.ToLower().Trim())) > 0;
        }

        public List<UserEntity> GetUserEntities()
        {
            return _users;
        }
        private void LoadUserEntities()
        {
            var reader = ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var splittedLine = line.Split(',');
                var user = new UserEntity
                {
                    Name = splittedLine[0],
                    Email = splittedLine[1],
                    Phone = splittedLine[2],
                    Address = splittedLine[3],
                    UserType = Enum.Parse<UserEntityType>(splittedLine[4]),
                    Money = decimal.Parse(splittedLine[5]),
                };
                _users.Add(user);
            }

            reader.Close();
        }

        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
