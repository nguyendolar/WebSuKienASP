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

        public ActionResult GetCategoryById(int id)
        {
            User user = (User)Session["USER"];
            if (user == null)
            {
                return RedirectToAction("Login", "PublicAuthentication");
            }
            else
            {
                Category category = categoryDao.getById(id);
                ViewBag.category = category;
                ViewBag.events = eventDao.getByCategory(category.idCategory);
                return View();
            }
        }
    }
}