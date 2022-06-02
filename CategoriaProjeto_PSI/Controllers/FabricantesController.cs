using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
    }
}