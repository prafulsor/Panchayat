using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panchayat.Models;

namespace TASKMANAGER.Controllers
{
    public class AllTaskController : Controller
    {
        // GET: PanchayatController
        public ActionResult Index()
        {
            List<TaskActivity> list = TaskActivity.GetAllActivities();
            return View(list);
        }
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult ActivitiesForUser()
        {
            List<TaskActivity> list = TaskActivity.GetAllActivities();
            return View(list);
        }

        // GET: PanchayatController/Details/5
        public ActionResult Details(int id)
        {
            TaskActivity activity = TaskActivity.GetActivityById(id); 
            return View(activity);
        }
        public ActionResult ActivityDetailsForUser(int id)
        {
            TaskActivity activity = TaskActivity.GetActivityById(id); 
            return View(activity);
        }

        // GET: PanchayatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanchayatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskActivity activity)
        {
            try
            {
                TaskActivity.AddActivities(activity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PanchayatController/Edit/5
        public ActionResult Edit(int id)
        {
            TaskActivity activity = TaskActivity.GetActivityById(id);
            return View(activity);
        }

        // POST: PanchayatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskActivity activity)
        {
            try
            {
                TaskActivity.UpdateActivity(id, activity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PanchayatController/Delete/5
        public ActionResult Delete(int id)
        {
            TaskActivity activity = TaskActivity.GetActivityById(id);
            return View(activity);
        }

        // POST: PanchayatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskActivity activity)
        {
            try
            {
                TaskActivity.DeleteActivity(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
