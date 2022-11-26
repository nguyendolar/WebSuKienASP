using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Public
{
    public class PublicCategoryController : Controller
    {
        CategoryDao categoryDao = new CategoryDao();
        EventDao eventDao = new EventDao();
        // GET: PublicCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryById(int id,int page)
        {
                Category category = categoryDao.getById(id);
                if (page == 0)
                {
                    page = 1;
                }
                ViewBag.List = eventDao.GetEventByCategory(page, 6, id);
                ViewBag.tag = page;
                ViewBag.pageSize = eventDao.GetEventBycategoryNumber(id);
                ViewBag.CategoryId = id;
                ViewBag.category = category;
                ViewBag.events = eventDao.getByCategory(category.idCategory);
                return View();
        }
    }
}