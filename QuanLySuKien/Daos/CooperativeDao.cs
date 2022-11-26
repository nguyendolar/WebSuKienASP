using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class CooperativeDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();

        public List<Cooperative> getAll()
        {
            return myDb.cooperatives.ToList();
        }
        public void Add(Cooperative cooperative)
        {
            myDb.cooperatives.Add(cooperative);
            myDb.SaveChanges();
        }
        public Cooperative getById(int id)
        {
            return myDb.cooperatives.FirstOrDefault(x => x.idCooperative == id);
        }
        public void Update(Cooperative cooperative)
        {
            var obj = myDb.cooperatives.FirstOrDefault(x => x.idCooperative == cooperative.idCooperative);
            obj.name = cooperative.name;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.cooperatives.FirstOrDefault(x => x.idCooperative == id);
            myDb.cooperatives.Remove(obj);
            myDb.SaveChanges();
        }
    }
}