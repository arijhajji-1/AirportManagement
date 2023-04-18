using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEBA.Controllers
{
    public class FlightController : Controller
    {
        // GET: FlightController
        private IServiceFlight serviceFlight;
        private IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;   
        }
        public ActionResult Index(string destination)
        {

            var list = serviceFlight.GetAll().ToList();
            if (destination != null)
            {
                list = list.Where(f => f.Destination.Contains(destination)).ToList();
            }
            return View(list);
        }
       


        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Search(string destination)
        {
            return View("index", serviceFlight.GetAll().Where(f => f.Destination.Contains(destination)));
        }
        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.Planes =new SelectList(servicePlane.GetAll(), "PlaneId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection, IFormFile piloteFile)
        {
            try
            {
                if (piloteFile!=null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", piloteFile.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    piloteFile.CopyTo(stream);
                    collection.Pilote = piloteFile.FileName;
                }
             

                serviceFlight.Add(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
