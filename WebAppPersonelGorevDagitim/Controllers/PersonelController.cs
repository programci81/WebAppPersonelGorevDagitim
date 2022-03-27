using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using WebAppPersonelGorevDagitim.Models;

namespace WebAppPersonelGorevDagitim.Controllers
{
    public class PersonelController : Controller
    {
        // GET: PersonelController
        public ActionResult Index()
        {
            PersonelRepository personelRepository = new PersonelRepository();
            IEnumerable<Personel> personels= personelRepository.GetPersonels(null, null);
            return View(personels);
        }

        // GET: PersonelController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null || id <= 0)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            PersonelRepository personelRepository = new PersonelRepository();
            Personel personel = personelRepository.GetPersonels(id, null).FirstOrDefault();

            if (personel == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return View(personel);
        }

        // GET: PersonelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(Personel model)
        {
            PersonelRepository personelRepository = new PersonelRepository();
            DBOperationResult result = personelRepository.CreatePersonel(model);

            if (result.Ok)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Create", new HtmlString("Hata Oluştu:" + result.exception.Message).Value);
                //return RedirectToAction("ErrorIB", "Home", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorDescription = result.exception.Message });
                //throw result.exception;                
            }

            return View(model);
        }

        // GET: PersonelController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            PersonelRepository personelRepository = new PersonelRepository();
            Personel personel = personelRepository.GetPersonels(id, null).FirstOrDefault();

            if (personel == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return View(personel);
        }

        // POST: PersonelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        public ActionResult Edit(int id, Personel model)
        {
            model.PersonelId = id; // modify
            PersonelRepository personelRepository = new PersonelRepository();
            DBOperationResult result = personelRepository.UpdatePersonel(model);

            if (result.Ok)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Edit", new HtmlString("Hata Oluştu:" + result.exception.Message).Value);
                //return RedirectToAction("ErrorIB", "Home", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorDescription = result.exception.Message });
                //throw result.exception;                
            }

            return View(model);
        }

        // GET: PersonelController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            PersonelRepository personelRepository = new PersonelRepository();
            Personel personel = personelRepository.GetPersonels(id, null).FirstOrDefault();

            if (personel == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            return View(personel);
        }

        // POST: PersonelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        public ActionResult Delete(int id, Personel model)
        {
            model.PersonelId = id; // modify
            PersonelRepository personelRepository = new PersonelRepository();
            DBOperationResult result = personelRepository.DeletePersonel(model);

            if (result.Ok)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Delete", new HtmlString("Hata Oluştu:" + result.exception.Message).Value);
                //return RedirectToAction("ErrorIB", "Home", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorDescription = result.exception.Message });
                //throw result.exception;                
            }

            return View(model);
        }
    }
}
