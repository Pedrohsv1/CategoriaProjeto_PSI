using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoriaProjeto_PSI.Models;

namespace CategoriaProjeto_PSI.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria { CategoriaId = 1, Nome = "Camisa" },
            new Categoria { CategoriaId = 2, Nome = "Gorro" },
            new Categoria { CategoriaId = 3, Nome = "Chapeu" },
            new Categoria { CategoriaId = 4, Nome = "Casaco" },
            new Categoria { CategoriaId = 5, Nome = "Macacão" }
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
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
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        //EDIT:
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        //EDIT POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        //DETAILS:
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        //DELETE:
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        //DELETE POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }
    }
}