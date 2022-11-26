using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminGuestController : Controller
    {
        GuestDao guestDao = new GuestDao();
        EventDao eventDao = new EventDao();
        // GET: AdminVoucher
        public ActionResult Index(string msg)
        {
            User user = (User)Session["ADMIN"];
            if (user == null)
            {
                return RedirectToAction("Login", "AdminAuthentication");
            }
            else
            {
                ViewBag.Msg = msg;
                ViewBag.List = guestDao.getAll();
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Guest guest)
        {
            guestDao.Add(guest);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Guest guest)
        {
            guestDao.Update(guest);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Guest guest)
        {
            var check = eventDao.getByGuest(guest.idGuest);
            if (check.Count == 0)
            {
                guestDao.Delete(guest.idGuest);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}