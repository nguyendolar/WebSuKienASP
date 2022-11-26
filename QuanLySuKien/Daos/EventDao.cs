using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class EventDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();

        public List<Event> getByGuest(int id)
        {
            return myDb.events.Where(x => x.idGuest == id).ToList();
        }

        public List<Event> getByCooperative(int id)
        {
            return myDb.events.Where(x => x.idCooperative == id).ToList();
        }

        public List<Event> getByOrgansier(int id)
        {
            return myDb.events.Where(x => x.idOrganiser == id).ToList();
        }

        public List<Event> getByCategory(int id)
        {
            return myDb.events.Where(x => x.idCategory == id && x.status == 1).ToList();
        }

        public List<Event> getByUser(int id)
        {
            return myDb.events.Where(x => x.idUser == id).OrderByDescending(x => x.date).ToList();
        }

        public List<Event> getAll()
        {
            return myDb.events.OrderByDescending(x => x.date).ToList();
        }

        public List<Event> GetTopSix()
        {
            return myDb.events.Where(x => x.status == 1).Take(6).OrderByDescending(x => x.date).ToList();
        }

        public List<Event> GetApprove()
        {
            return myDb.events.Where(x => x.status == 1).OrderByDescending(x => x.date).ToList();
        }
        public void Add(Event obj)
        {
            myDb.events.Add(obj);
            myDb.SaveChanges();
        }
        public Event getById(int id)
        {
            return myDb.events.FirstOrDefault(x => x.idEvent == id);
        }
        public void Update(Event evt)
        {
            var obj = myDb.events.FirstOrDefault(x => x.idEvent == evt.idEvent);
            obj.name = evt.name;
            obj.content = evt.content;
            obj.date = evt.date;
            obj.image = evt.image;
            obj.participant = evt.participant;
            obj.idCategory = evt.idCategory;
            obj.idCooperative = evt.idCooperative;
            obj.idGuest = evt.idGuest;
            obj.idOrganiser = evt.idOrganiser;
            myDb.SaveChanges();
        }

        public void Approve(int id)
        {
            var obj = myDb.events.FirstOrDefault(x => x.idEvent == id);
            obj.status = 1;
            myDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = myDb.events.FirstOrDefault(x => x.idEvent == id);
            myDb.events.Remove(obj);
            myDb.SaveChanges();
        }
    }
}