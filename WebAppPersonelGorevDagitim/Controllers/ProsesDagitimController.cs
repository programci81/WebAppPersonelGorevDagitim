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
    public class ProsesDagitimController : Controller
    {
        // GET: ProsesDagitimController
        public ActionResult Index(TarihPrm tarihPrm)
        {
            if (tarihPrm.Tarih == null)
            {
                tarihPrm.Tarih = DateTime.Today;
            }

            ProsesDagitimRepository prosesDagitimRepository = new ProsesDagitimRepository();
            IEnumerable<ProsesDagitimView> prosesDagitims = prosesDagitimRepository.GetProsesDagitims(tarihPrm.Tarih.Value, null);
            tarihPrm.prosesDagitim = prosesDagitims;
            return View(tarihPrm);
        }

        // TODO: modift for create
        // GET: ProsesDagitimController/Create
        public ActionResult Create(DateTime? Tarih)
        {
            if (Tarih == null)
            {
                Tarih = DateTime.Today;
            }

            if (ViewBag.fromDate == null)
            {
                ViewBag.fromDate = Tarih;
            }
            
            return View();
        }

        // POST: ProsesDagitimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildList(DateTime? Tarih)
        {
            ViewBag.fromDate = Tarih.Value;

            ProsesDagitimRepository prosesDagitimRepository = new ProsesDagitimRepository();
            DBOperationResult result = prosesDagitimRepository.DagitimListesiOlustur(Tarih.Value);

            try
            {
                if (result.Ok)
                {
                    return RedirectToAction(nameof(Index), new TarihPrm {Tarih = Tarih.Value, prosesDagitim = null});
                }
                else
                {
                    ModelState.AddModelError("Create", new HtmlString("Hata Oluştu:" + result.exception.Message).Value);
                    //return RedirectToAction("ErrorIB", "Home", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorDescription = result.exception.Message });
                    //throw result.exception;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        
    }
}
