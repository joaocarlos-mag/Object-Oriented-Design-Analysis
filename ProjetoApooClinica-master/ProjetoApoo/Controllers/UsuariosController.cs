using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Persistencia.DAL;
using Persistencia.Contexts;

namespace ProjetoApoo.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        // GET: Procedimentos
        public ActionResult Indexusuario()
        {
            return View(usuarioDAL.ObterUsuariosClassificadosPorNome());
        }

        // GET: Procedimentos/Details/5
        public ActionResult Detailsusuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuariosPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Procedimentos/Create
        public ActionResult Createusuario()
        {
            return View();
        }

        // POST: Procedimentos/Create
        [HttpPost]
        public ActionResult Createusuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioDAL.GravarUsuario(usuario);
                    return RedirectToAction("IndexUsuario");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Procedimentos/Edit/5
        public ActionResult Editusuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuariosPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Procedimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioDAL.GravarUsuario(usuario);
                    return RedirectToAction("Indexusuario");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Procedimentos/Delete/5
        public ActionResult Deleteusuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuariosPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteusuario(long id)
        {
            try
            {
                Usuario usuario = usuarioDAL.EliminarUsuarioPorId(id);
                return RedirectToAction("Indexusuario");
            }
            catch
            {
                return View();
            }
        }
    }
}
