using RemCua.Entities.Models;
using RemCua.Repository.Infrastructure;
using RemCua.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCua.Service
{
    public interface IUserService
    {
        User Add(User user);

        void Update(User user);

        User Delete(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

        int Login(string userName, string password);

        void Active(int id, bool status);

        User GetByUserName(string username);

        bool CheckUserName(string userName);

        bool CheckEmail(string email);

        void SaveChanges();
    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public int Login(string userName, string password)
        {
            return _userRepository.Login(userName, password);
        }

        public void Active(int id, bool status)
        {
            _userRepository.Active(id, status);
        }
        public User GetByUserName(string username)
        {
            return _userRepository.GetByUserName(username);
        }

        public bool CheckUserName(string userName)
        {
            return _userRepository.CheckUserName(userName);
        }

        public bool CheckEmail(string email)
        {
            return _userRepository.CheckEmail(email);
        }
    }
}
