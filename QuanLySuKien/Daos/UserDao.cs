using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class UserDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();
        public bool checkLogin(string userName, string password)
        {
            var obj = myDb.users.FirstOrDefault(x => x.userName == userName && x.password == password);
            if (obj == null) { return false; }
            return true;
        }

        public User getUserByUserName(string userName)
        {
            return myDb.users.FirstOrDefault(x => x.userName.Equals(userName));
        }

        public List<User> getStudent()
        {
            return myDb.users.Where(x => x.role.Equals("student")).ToList();
        }
        public void Add(User user)
        {
            myDb.users.Add(user);
            myDb.SaveChanges();
        }
        public User getById(int id)
        {
            return myDb.users.FirstOrDefault(x => x.idUser == id);
        }
        public void Update(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.idUser == user.idUser);
            obj.userName = user.userName;
            obj.password = user.password;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.users.FirstOrDefault(x => x.idUser == id);
            myDb.users.Remove(obj);
            myDb.SaveChanges();
        }
    }
}