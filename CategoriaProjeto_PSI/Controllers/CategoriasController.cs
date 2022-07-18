using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CategoriaProjeto_PSI.Context;
using CategoriaProjeto_PSI.Models;

namespace CategoriaProjeto_PSI.Controllers
{
    public class CategoriasController : Controller
    {
        /*private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria { CategoriaId = 1, Nome = "Camisa" },
            new Categoria { CategoriaId = 2, Nome = "Gorro" },
            new Categoria { CategoriaId = 3, Nome = "Chapeu" },
            new Categoria { CategoriaId = 4, Nome = "Casaco" },
            new Categoria { CategoriaId = 5, Nome = "Macacão" }
        };*/

        // GET: Categorias
        private EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        //CREATE:
        public ActionResult Create()
        {
            return View();
        }

        //CREATE POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //EDIT:
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //EDIT POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        //DETAILS:
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //DELETE:
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //DELETE POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + categoria.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}