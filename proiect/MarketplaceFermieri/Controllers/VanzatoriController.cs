using BusinessLayer_DBFirst;
using DTOs;
using Repository_DBFirst;
using System.Collections.Generic;
using System.Net;
//using System.Web.Http;
using System.Web.Mvc;

namespace MarketplaceFermieri.Controllers
{
    public class VanzatoriController : Controller
    {

        private marketplace_fermieriEntities _db;
        public VanzatoriController()
        {
            _db = new marketplace_fermieriEntities();
        }

        // GET: Vanzatori
        public ActionResult Index()
        {
            return View();
        }


        //those below are mvc specific

        // GET: Vanzatori
        public ActionResult IndexMVC()
        {
            IEnumerable<ReadVanzatorViewModel> vanzatoriViewModel = new List<ReadVanzatorViewModel>();
            vanzatoriViewModel = new VanzatorServices(_db).GetAll();
            return View(vanzatoriViewModel);
        }

        // GET: Companies/Details/5
        public ActionResult DetailsMVC(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReadVanzatorViewModel v1 = new VanzatorServices(_db).Get((int)id);
            return View(v1);
        }
        public ActionResult CreateMVC()
        {
            CreateVanzatorViewModel model = new CreateVanzatorViewModel();

            return View(model);
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMVC(CreateVanzatorViewModel vanzatorViewModel)
        {
            if (ModelState.IsValid)
            {
                new VanzatorServices(_db).Add(vanzatorViewModel);
                return RedirectToAction("Index");
            }

            return View(vanzatorViewModel);
        }

        // GET: Companies/Edit/5
        public ActionResult EditMVC(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReadVanzatorViewModel v1 = new VanzatorServices(_db).Get((int)id);
            if (v1 == null)
            {
                return HttpNotFound();
            }
            return View(v1);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMVC([Bind(Include = "idVanzator,numeVanzator,prenumeVanzator,email,numarTelefon")] UpdateVanzatorViewModel vanzatorViewModel)
        {
            if (ModelState.IsValid)
            {
                new VanzatorServices(_db).Update(vanzatorViewModel);
                return RedirectToAction("Index");
            }
            return View(vanzatorViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}