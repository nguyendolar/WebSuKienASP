using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class GuestDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();

        public List<Guest> getAll()
        {
            return myDb.guests.ToList();
        }
        public void Add(Guest guest)
        {
            myDb.guests.Add(guest);
            myDb.SaveChanges();
        }
        public Guest getById(int id)
        {
            return myDb.guests.FirstOrDefault(x => x.idGuest == id);
        }
        public void Update(Guest guest)
        {
            var obj = myDb.guests.FirstOrDefault(x => x.idGuest == guest.idGuest);
            obj.name = guest.name;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.guests.FirstOrDefault(x => x.idGuest == id);
            myDb.guests.Remove(obj);
            myDb.SaveChanges();
        }
    }
}