using Exams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Diagnostics;


namespace Exams.Controllers
{
    public class HomeController : Controller
    {
        ExamContext db = new ExamContext();

        public ActionResult Index(string msg = "Выберите удобное время.")
        {
            ViewBag.Message = msg;
            return View(db.Appointments.ToList());
        }

        [HttpGet]
        public ActionResult EditAppointment(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment != null)
            {
                return View(appointment);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditAppointment(Appointment appointment)
        {
            var checkModification = db.Appointments.AsNoTracking().Where(x => x.ExamId == appointment.ExamId).FirstOrDefault().Student;
            if (checkModification == null)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { msg = "Вы успешно записались." });
            }
            else
            {

                return RedirectToAction("Index", new { msg = "Данное время занято. Выберите другое время." });
            }
        }
    }
}