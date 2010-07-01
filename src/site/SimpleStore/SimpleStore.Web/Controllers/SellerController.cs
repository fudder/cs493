using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleStore.Core;
using SimpleStore.Core.DataInterfaces;
using SharpArch.Core;
using SharpArch.Web;
using SharpArch.Web.NHibernate;
using SharpArch.Core.PersistenceSupport;

namespace SimpleStore.Web.Controllers
{
    [HandleError]
    public class SellerController : Controller
    {
        private readonly IRepository<Seller> sellerRepository;

        public SellerController(IRepository<Seller> sellerRepository) 
        {
            Check.Require(sellerRepository != null, "sellerRepository may not be null");
            this.sellerRepository = sellerRepository;
        }

        public ActionResult Index()
        {
            return View(sellerRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        [Transaction]
        public ActionResult Create(Seller newSeller)
        {
            try
            {
                newSeller.Created = DateTime.Now;
                sellerRepository.SaveOrUpdate(newSeller);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewData["Exception"] = ex;
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View(sellerRepository.Get(id));
        }

        [HttpPost]
        [Transaction]
        public ActionResult Edit(int id, Seller seller)
        {
            try
            {
                Seller updated = sellerRepository.Get(id);
                updated.Email = seller.Email;
                updated.EbayUser = seller.EbayUser;
                sellerRepository.SaveOrUpdate(updated);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Exception"] = ex;
                return View(sellerRepository.Get(id));
            }
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                Seller gone = sellerRepository.Get(id);
                sellerRepository.Delete(gone);
                sellerRepository.DbContext.CommitChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Exception"] = ex.InnerException;
                return View("Index", sellerRepository.GetAll());
            }
        }
    }
}
