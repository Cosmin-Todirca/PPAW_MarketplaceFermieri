using BusinessLayer_DBFirst;
using Repository_DBFirst;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels;

namespace MarketplaceFermieri.Controllers
{
    public class ProduseController : Controller
    {
        private marketplace_fermieriEntities _db = new marketplace_fermieriEntities();

        public ProduseController()
        {
            _db = new marketplace_fermieriEntities();
        }

        public ActionResult Index()//pentru API ai nevoie si de asa ceva
        {
            ViewBag.Title = "Pagina cu produse";

            return View();
        }

        // GET: Produse
        public ActionResult IndexMVC()
        {
            IEnumerable<ReadProdusCuVanzatorViewModel> produsCuVanzatoriViewModel = new List<ReadProdusCuVanzatorViewModel>();
            produsCuVanzatoriViewModel = new ProdusServices(_db).GetProduseCuVanzatori();
            return View(produsCuVanzatoriViewModel);
        }

        // GET: Produse/Create
        public ActionResult CreateMVC()
        {
            CreateProdusViewModelCuDropdown model = new CreateProdusViewModelCuDropdown();

            return View(model);
        }

        // POST: Produse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMVC(CreateProdusViewModelCuDropdown produsViewModel)
        {
            if (ModelState.IsValid)
            {
                new ProdusServices(_db).AddCuDropdown(produsViewModel);
                return RedirectToAction("IndexMVC");
            }

            return View(produsViewModel);
        }
    }
}