﻿
using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AuthenticateUser(string username, string password)
        {
            Users user = _userRepository.GetUser(username, password);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public Users CreatAccount(Users account)
        {
            return _userRepository.CreatNewUserAcc(account);
        }

        public Users UpdatePassAcc(Users account)
        {
            return _userRepository.UpdateUserPass(account);
        }

        public string RemoveAcc(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}
