using RemCua.Entities.Models;
using RemCua.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCua.Repository.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        int Login(string userName, string password);
        void Active(int id, bool status);
        bool CheckUserName(string userName);
        bool CheckEmail(string email);
        User GetByUserName(string username);
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public int Login(string userName, string password)
        {
            var result = DbContext.Users.SingleOrDefault(x => x.UserName == userName);//lấy giá trị của User Name
            if (result == null)//Nếu bằng null
            {
                return 0;//Nhập Tài Khoản Và Mật Khẩu
            }
            else    //Khác Null
            {
                if (result.Status == false)//Trạng Thaí = False
                {
                    return -1;  //Tài Khoản Đang Bị Khóa
                }
                else  //Trạng Thái == true
                {
                    if (result.Password == password)  //Nếu Password đúng
                        return 1; //Đăng Nhập Thành Công
                    else
                        return -2; //Sai tài khoản và mật khẩu
                }
            }
        }


        public void Active(int id, bool status)
        {
            var data = DbContext.Users.SingleOrDefault(x => x.ID == id);
            data.Status = true;
            DbContext.SaveChanges();
        }

        public bool CheckEmail(string email)
        {
            return DbContext.Users.Count(x => x.UserName == email) > 0;
        }

        public bool CheckUserName(string userName)
        {
            return DbContext.Users.Count(x => x.UserName == userName) > 0;
        }

        public User GetByUserName(string username)
        {
            return DbContext.Users.SingleOrDefault(x => x.UserName == username);
        }
    }
}
