using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Public
{
    public class PublicEventController : Controller
    {
        // GET: PublicEvent
        EventDao eventDao = new EventDao();
        CategoryDao categoryDao = new CategoryDao();
        OrgansierDao organsierDao = new OrgansierDao();
        CooperativeDao cooperativeDao = new CooperativeDao();
        GuestDao guestDao = new GuestDao();
        UserDao userDao = new UserDao();
        InformationDao informationDao = new InformationDao();
        public ActionResult Index(string msg)
        {
            User user = (User)Session["USER"];
            ViewBag.Msg = msg;
            ViewBag.List = eventDao.getByUser(user.idUser);
            ViewBag.Category = categoryDao.getAll();
            ViewBag.Organsier = organsierDao.getAll();
            ViewBag.Cooperative = cooperativeDao.getAll();
            ViewBag.Guest = guestDao.getAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Category = categoryDao.getAll();
            ViewBag.Organsier = organsierDao.getAll();
            ViewBag.Cooperative = cooperativeDao.getAll();
            ViewBag.Guest = guestDao.getAll();
            return View();
        }


        [HttpGet]
        public ActionResult Update(int id,string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.Event = eventDao.getById(id);
            ViewBag.Category = categoryDao.getAll();
            ViewBag.Organsier = organsierDao.getAll();
            ViewBag.Cooperative = cooperativeDao.getAll();
            ViewBag.Guest = guestDao.getAll();
            return View();
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Event evt)
        {
            User user = (User)Session["USER"];
            Information information = informationDao.GetInformationByIdUser(user.idUser);
            if(information == null) {
                return RedirectToAction("Index", new { msg = "4" });
            }
            else if(information != null && information.email == null)
            {
                return RedirectToAction("Index", new { msg = "5" });
            }
            else
            {
                TimeSpan ThoiGianO = evt.date - DateTime.Now; // Thời gian khách ở.
                if (ThoiGianO.Days >= 2)
                {
                    var file = Request.Files["file"];
                    string reName = DateTime.Now.Ticks.ToString() + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/images/" + reName));
                    evt.image = reName;
                    evt.status = 0;
                    evt.idUser = user.idUser;
                    eventDao.Add(evt);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    return RedirectToAction("Index", new { msg = "6" });
                }

               
            }
           
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Event evt)
        {
            User user = (User)Session["USER"];
            Information information = informationDao.GetInformationByIdUser(user.idUser);
            string reName = "";
            var objCourse = eventDao.getById(evt.idEvent);
            var file = Request.Files["file"];
            if (file.FileName == "")
            {
                reName = objCourse.image;
            }
            else
            {
                reName = DateTime.Now.Ticks.ToString() + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            }
            if (information == null)
            {
                return RedirectToAction("Update", new { id = evt.idEvent, msg = "4" });
            }
            else if (information != null && information.email == null)
            {
                return RedirectToAction("Update", new { id = evt.idEvent, msg = "5" });
            }
            else
            {
                TimeSpan ThoiGianO = evt.date - DateTime.Now; 
                if (ThoiGianO.Days >= 2)
                {
                    evt.image = reName;
                    eventDao.Update(evt);
                    return RedirectToAction("Update", new { id = evt.idEvent , msg = "1" }) ;
                }
                else
                {
                    return RedirectToAction("Update", new { id = evt.idEvent, msg = "6" });
                }


            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Event = eventDao.getById(id);
            ViewBag.Category = categoryDao.getAll();
            ViewBag.Organsier = organsierDao.getAll();
            ViewBag.Cooperative = cooperativeDao.getAll();
            ViewBag.Guest = guestDao.getAll();
            return View();
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Event evt)
        {
            User user = (User)Session["USER"];
            var file = Request.Files["file"];
            string reName = DateTime.Now.Ticks.ToString() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            evt.image = reName;
            evt.status = 0;
            evt.idUser = user.idUser;
            eventDao.Add(evt);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}