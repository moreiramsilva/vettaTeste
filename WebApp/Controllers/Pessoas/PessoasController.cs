using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp
{
    public class PessoasController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Pessoas
        public ActionResult Index()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "TIPO PESSOA", Value = "" });
            items.Add(new SelectListItem { Text = "PF", Value = "F" });
            items.Add(new SelectListItem { Text = "PJ", Value = "J" });
            ViewBag.SelectedStatus = items;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "CLASSIFICAÇÃO", Value = "" });
            items2.Add(new SelectListItem { Text = "ATIVO", Value = "A" });
            items2.Add(new SelectListItem { Text = "INATIVO", Value = "I" });
            items2.Add(new SelectListItem { Text = "PREFERENCIAL", Value = "P" });
            ViewBag.SelectedStatus2 = items2;

            return View(db.Pessoa.ToList());
        }

        public ActionResult preparaFiltros(String nomeRazaoSocial, String email)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "TIPO PESSOA", Value = "" });
            items.Add(new SelectListItem { Text = "PF", Value = "F" });
            items.Add(new SelectListItem { Text = "PJ", Value = "J" });
            ViewBag.SelectedStatus = items;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "CLASSIFICAÇÃO", Value = "" });
            items2.Add(new SelectListItem { Text = "ATIVO", Value = "A" });
            items2.Add(new SelectListItem { Text = "INATIVO", Value = "I" });
            items2.Add(new SelectListItem { Text = "PREFERENCIAL", Value = "P" });
            ViewBag.SelectedStatus2 = items2;

            IQueryable<Pessoa> query = db.Pessoa;

            if (email != "")
            {
                query = query.Where(x => x.Email.Contains(email));
            }

            if (nomeRazaoSocial != "")
            {
                query = query.Where(x => x.NomeRazaoSocial.Contains(nomeRazaoSocial));
            }

            List<Pessoa> lista = query.ToList();
            return View("index", lista);
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "TIPO PESSOA", Value = "" });
            items.Add(new SelectListItem { Text = "PF", Value = "F" });
            items.Add(new SelectListItem { Text = "PJ", Value = "J" });
            ViewBag.SelectedStatus = items;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "CLASSIFICAÇÃO", Value = "" });
            items2.Add(new SelectListItem { Text = "ATIVO", Value = "A" });
            items2.Add(new SelectListItem { Text = "INATIVO", Value = "I" });
            items2.Add(new SelectListItem { Text = "PREFERENCIAL", Value = "P" });
            ViewBag.SelectedStatus2 = items2;

            var pessoaViewModel = new Pessoa
            {
                Telefone = new List<Telefone>
                {
                    new Telefone()
                }
            };

            return View(pessoaViewModel);
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NomeRazaoSocial,Cep,Email,Classificacao,CpfCnpj,TipoPessoa")] Pessoa pessoa, List<Telefone> Telefone)
        {
            if (ModelState.IsValid)
            {
                if (Telefone != null) {
                    pessoa.Telefone = Telefone;
                }

                db.Pessoa.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "TIPO PESSOA", Value = "" });
            items.Add(new SelectListItem { Text = "PF", Value = "F" });
            items.Add(new SelectListItem { Text = "PJ", Value = "J" });
            ViewBag.SelectedStatus = items;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "CLASSIFICAÇÃO", Value = "" });
            items2.Add(new SelectListItem { Text = "ATIVO", Value = "A" });
            items2.Add(new SelectListItem { Text = "INATIVO", Value = "I" });
            items2.Add(new SelectListItem { Text = "PREFERENCIAL", Value = "P" });
            ViewBag.SelectedStatus2 = items2;

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "TIPO PESSOA", Value = "" });
            items.Add(new SelectListItem { Text = "PF", Value = "F" });
            items.Add(new SelectListItem { Text = "PJ", Value = "J" });
            ViewBag.SelectedStatus = items;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "CLASSIFICAÇÃO", Value = "" });
            items2.Add(new SelectListItem { Text = "ATIVO", Value = "A" });
            items2.Add(new SelectListItem { Text = "INATIVO", Value = "I" });
            items2.Add(new SelectListItem { Text = "PREFERENCIAL", Value = "P" });
            ViewBag.SelectedStatus2 = items2;

            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeRazaoSocial,Cep,Email,Classificacao,CpfCnpj,TipoPessoa")] Pessoa pessoa, List<Telefone> Telefone)
        {
            if (ModelState.IsValid)
            {
                if (Telefone != null)
                {
                    pessoa.Telefone = Telefone;
                }

                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "TIPO PESSOA", Value = "" });
            items.Add(new SelectListItem { Text = "PF", Value = "F" });
            items.Add(new SelectListItem { Text = "PJ", Value = "J" });
            ViewBag.SelectedStatus = items;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "CLASSIFICAÇÃO", Value = "" });
            items2.Add(new SelectListItem { Text = "ATIVO", Value = "A" });
            items2.Add(new SelectListItem { Text = "INATIVO", Value = "I" });
            items2.Add(new SelectListItem { Text = "PREFERENCIAL", Value = "P" });
            ViewBag.SelectedStatus2 = items2;

            return View(pessoa);
        }

        public ActionResult AddNewTelefone()
        {
            var Telefone = new Telefone();
            return PartialView("_Telefone", Telefone);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoa.Find(id);
            db.Pessoa.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
