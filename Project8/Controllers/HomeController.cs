using Project8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Project8.Controllers
{
    public class HomeController : Controller
    {
        Project8Entities2 db = new Project8Entities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string name,string subject,string email,string message)
        {
            ViewBag.Message = "Your contact page.";
            MailMessage mail = new MailMessage();
            mail.To.Add("jaberfahd2233@gmail.com");
            mail.From = new MailAddress("jaberfahd2233@gmail.com");
            mail.Subject = subject +" " + email;

            mail.Body = message;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("jaberfahd2233", "obsrmfoexbukaspu");
            smtp.Send(mail);
            return View();
        }
        public ActionResult Collages()
        {
            var collages = db.Colleges.ToList();
            return View(collages);
        }
        public ActionResult Majors(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Collages");
            }
            var majors = db.Majors.Where(x => x.College_Id == id).ToList();
            return View(majors);
        }

        public ActionResult singleMajor(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Majors");
            }
            var majors = db.Majors.Where(x => x.Major_Id == id).ToList();
            return View(majors);
        }
    }
}