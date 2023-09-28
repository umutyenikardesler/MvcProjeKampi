using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager:ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public void AdminAdd(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin AdminLogin(Admin admin)
        {
            return _loginDal.Get(x=>x.AdminUserName == admin.AdminUserName &&  x.AdminPassword == admin.AdminPassword);
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }
        Admin ILoginService.GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
