using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminEventController : Controller
    {
        EventDao eventDao = new EventDao();
        CategoryDao categoryDao = new CategoryDao();
        OrgansierDao organsierDao = new OrgansierDao();
        CooperativeDao cooperativeDao = new CooperativeDao();
        GuestDao guestDao = new GuestDao();
        UserDao userDao = new UserDao();
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
                ViewBag.List = eventDao.getAll();
                ViewBag.Category = categoryDao.getAll();
                ViewBag.Organsier = organsierDao.getAll();
                ViewBag.Cooperative = cooperativeDao.getAll();
                ViewBag.Guest = guestDao.getAll();
                return View();
            }
            
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Event evt)
        {
            TimeSpan ThoiGianO =  evt.date - DateTime.Now; // Thời gian khách ở.
            if (ThoiGianO.Days >= 2)
            {
                User user = (User)Session["ADMIN"];
                var file = Request.Files["file"];
                string reName = DateTime.Now.Ticks.ToString() + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/images/" + reName));
                evt.image = reName;
                evt.status = 1;
                evt.idUser = user.idUser;
                eventDao.Add(evt);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "5" });
            }
            
        }

        [HttpPost]
        public ActionResult Approvel(FormCollection form)
        {
            int idUser = Int32.Parse(form["id_user"]);
            int idEvent = Int32.Parse(form["idEvent"]);
            var user = userDao.getById(idUser);
            eventDao.Approve(idEvent);
            string email = user.Informations.FirstOrDefault().email;
            string html = "Your event has been approved";
            sendMail(email, html);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult Feedback(FormCollection form)
        {
            int idUser = Int32.Parse(form["id_user"]);
            var content = form["content"];
            var user = userDao.getById(idUser);
            string email = user.Informations.FirstOrDefault().email;
            string html = "Feedback : " + content;
            sendMail(email, html);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public void sendMail(string email, string body)
        {
            var formEmailAddress = ConfigurationManager.AppSettings["FormEmailAddress"].ToString();
            var formEmailDisplayName = ConfigurationManager.AppSettings["FormEmailDisplayName"].ToString();
            var formEmailPassword = ConfigurationManager.AppSettings["FormEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPost"].ToString();
            bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            MailMessage message = new MailMessage(new MailAddress(formEmailAddress, formEmailDisplayName), new MailAddress(email));
            message.Subject = "Event Website Notification";
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(formEmailAddress, formEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}