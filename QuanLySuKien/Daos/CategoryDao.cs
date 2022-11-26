using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class CategoryDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();

        public List<Category> getAll()
        {
            return myDb.categories.ToList();
        }
        public void Add(Category category)
        {
            myDb.categories.Add(category);
            myDb.SaveChanges();
        }
        public Category getById(int id)
        {
            return myDb.categories.FirstOrDefault(x => x.idCategory == id);
        }
        public void Update(Category category)
        {
            var obj = myDb.categories.FirstOrDefault(x => x.idCategory == category.idCategory);
            obj.name = category.name;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.categories.FirstOrDefault(x => x.idCategory == id);
            myDb.categories.Remove(obj);
            myDb.SaveChanges();
        }
    }
}