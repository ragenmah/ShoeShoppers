using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository userRepository)
        {
            _repository = userRepository;
        }


        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public User GetUserById(int userId) => _repository.GetUserById(userId);

        public void UpdateUser(User user)
        {
            _repository.UpdateUser( user);
        }
        public void DeletePayment(int userId)
        {
            _repository.DeleteUser(userId);
        }
    }
}