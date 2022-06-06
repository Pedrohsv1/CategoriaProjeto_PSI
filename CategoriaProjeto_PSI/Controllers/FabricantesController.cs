using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CategoriaProjeto_PSI.Context;
using CategoriaProjeto_PSI.Models;

namespace CategoriaProjeto_PSI.Controllers
{
    public class FabricantesController : Controller
    {
        private static IList<Fabricante> fabricantes = new List<Fabricante>()
        {
            new Fabricante { FabricanteId = 1, Nome = "ITAU" },
            new Fabricante { FabricanteId = 2, Nome = "NUBANK" },
            new Fabricante { FabricanteId = 3, Nome = "PIX" },
            new Fabricante { FabricanteId = 4, Nome = "INTER" },
            new Fabricante { FabricanteId = 5, Nome = "CAIXA" }
        };
        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricantes);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {

            fabricantes.Add(fabricante);
            fabricante.FabricanteId = fabricantes.Select(m => m.FabricanteId).Max() + 1;
            return RedirectToAction("Index");
        }

        //EDIT:
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricantes .Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        //EDIT POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante categoria)
        {
            fabricantes.Remove(fabricantes.Where(c => c.FabricanteId == categoria.FabricanteId).First());
            fabricantes.Add(categoria);
            return RedirectToAction("Index");
        }
        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

    }
}