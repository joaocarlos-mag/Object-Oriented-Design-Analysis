using Modelo;
using Persistencia.DAL;
using System.Net;
using System.Web.Mvc;

namespace ProjetoApoo.Controllers
{
    public class AnimaisController : Controller
    {
        private EspecieDAL especieDAL = new EspecieDAL();
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        // GET: Procedimentos
        public ActionResult IndexEspecie()
        {
            return View(especieDAL.ObterEspeciesClassificadasPorNome());
        }

        // GET: Procedimentos/Details/5
        public ActionResult DetailsEspecie(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Especie especie = especieDAL.ObterEspeciesPorId((long)id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // GET: Procedimentos/Create
        public ActionResult CreateEspecie()
        {
            return View();
        }

        // POST: Procedimentos/Create
        [HttpPost]
        public ActionResult CreateEspecie(Especie especie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    especieDAL.GravarEspecie(especie);
                    return RedirectToAction("IndexEspecie");
                }
                return View(especie);
            }
            catch
            {
                return View(especie);
            }
        }

        // GET: Procedimentos/Edit/5
        public ActionResult EditEspecie(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Especie especie = especieDAL.ObterEspeciesPorId((long)id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Procedimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editespecie(Especie especie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    especieDAL.GravarEspecie(especie);
                    return RedirectToAction("IndexEspecie");
                }
                return View(especie);
            }
            catch
            {
                return View(especie);
            }
        }

        // GET: Procedimentos/Delete/5
        public ActionResult DeleteEspecie(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Especie especie = especieDAL.ObterEspeciesPorId((long)id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEspecie(long id)
        {
            try
            {
                Especie especie = especieDAL.EliminarEspeciePorId(id);
                return RedirectToAction("Indexespecie");
            }
            catch
            {
                return View();
            }
        }
    }
}