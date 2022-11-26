using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class OrgansierDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();

        public List<Organiser> getAll()
        {
            return myDb.organisers.ToList();
        }
        public void Add(Organiser organiser)
        {
            myDb.organisers.Add(organiser);
            myDb.SaveChanges();
        }
        public Organiser getById(int id)
        {
            return myDb.organisers.FirstOrDefault(x => x.idOrganiser == id);
        }
        public void Update(Organiser organiser)
        {
            var obj = myDb.organisers.FirstOrDefault(x => x.idOrganiser == organiser.idOrganiser);
            obj.name = organiser.name;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.organisers.FirstOrDefault(x => x.idOrganiser == id);
            myDb.organisers.Remove(obj);
            myDb.SaveChanges();
        }
    }
}