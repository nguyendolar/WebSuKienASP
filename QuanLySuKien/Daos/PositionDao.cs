using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Daos
{
    public class PositionDao
    {
        QuanLySuKienDbContext myDb = new QuanLySuKienDbContext();
        public List<Position> getAll()
        {
            return myDb.positions.ToList();
        }
    }
}