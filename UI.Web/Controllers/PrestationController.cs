using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class PrestationController : Controller


    {


        IPrestation prestationService;
        IPrestataires prestataireService;

        public PrestationController(IPrestation prestationService, IPrestataires prestataireService)
        {
            this.prestationService = prestationService;
            this.prestataireService = prestataireService;
        }

        // GET: PrestationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PrestationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestationController/Create
        public ActionResult Create()
        {
            ViewBag.PrestataireFK = new SelectList(prestataireService.GetAll(), "PrestataireId", "PrestataireId");
            return View();
        }

        // POST: PrestationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Prestation p)
        {
            try
            {
                prestationService.Add(p);
                prestationService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestationController/Edit/5
        public ActionResult Edit(int id)
        {
            //where prestataireID = id
            IEnumerable<Prestation> X = prestationService.GetMany( p => p.PrestataireFK == id); 

            return View(X);
        }

        // POST: PrestationController/Edit/5
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

        // GET: PrestationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestationController/Delete/5
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
