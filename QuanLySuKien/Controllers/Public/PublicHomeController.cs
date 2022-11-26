using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Public
{
    public class PublicHomeController : Controller
    {
        EventDao eventDao = new EventDao();
        CategoryDao categoryDao = new CategoryDao();
        OrgansierDao organsierDao = new OrgansierDao();
        CooperativeDao cooperativeDao = new CooperativeDao();
        GuestDao guestDao = new GuestDao();
        // GET: PublicHome
        public ActionResult Index()
        {       
            ViewBag.List = eventDao.GetTopSix();
            ViewBag.Category = categoryDao.getAll();
            ViewBag.Organsier = organsierDao.getAll();
            ViewBag.Cooperative = cooperativeDao.getAll();
            ViewBag.Guest = guestDao.getAll();
            return View();
        }
        public ActionResult Event(int page)
        {
                if (page == 0)
                {
                    page = 1;
                }
                ViewBag.List = eventDao.GetEvent(page, 6);
                ViewBag.tag = page;
                ViewBag.pageSize = eventDao.GetEventRoom();
                ViewBag.Category = categoryDao.getAll();
                ViewBag.Organsier = organsierDao.getAll();
                ViewBag.Cooperative = cooperativeDao.getAll();
                ViewBag.Guest = guestDao.getAll();
                return View();
        }

        public ActionResult DetailEvent(int id)
        {

                Event obj = eventDao.getById(id);
                ViewBag.Event = obj;
                return View();
        }
    }
}