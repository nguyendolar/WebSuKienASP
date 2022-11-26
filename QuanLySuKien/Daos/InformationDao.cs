using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class InformationDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();

        public void Add(Information obj)
        {
            myDb.informations.Add(obj);
            myDb.SaveChanges();
        }

        public void Update(Information evt)
        {
            var obj = myDb.informations.FirstOrDefault(x => x.idInformation == evt.idInformation);
            obj.name = evt.name;
            obj.idPosition = evt.idPosition;
            obj.idUser = evt.idUser;
            obj.phoneNumber = evt.phoneNumber;
            obj.email = evt.email;
            myDb.SaveChanges();
        }

        public Information GetInformationByIdUser(int idUser)
        {
            return myDb.informations.FirstOrDefault(x => x.idUser == idUser);
        }

    }
}