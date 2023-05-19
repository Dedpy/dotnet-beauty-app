using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class PrestatireController : Controller
    {

        readonly IPrestataires prestatairesService;

        public PrestatireController(IPrestataires prestatairesService)
        {
            this.prestatairesService = prestatairesService;
        }

        // GET: PrestatireController
        public ActionResult Index()
        {
            //get all prestataires ordrer by nom
            var prestataires = prestatairesService.GetAll().OrderBy(v => v.PrestataireNom);
            return View(prestataires); }

        // GET: PrestatireController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestatireController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrestatireController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestataire p)
        {
            try
            {
                prestatairesService.Add(p);
                prestatairesService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestatireController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestatireController/Edit/5
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

        // GET: PrestatireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestatireController/Delete/5
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
