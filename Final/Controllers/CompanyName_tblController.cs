using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class CompanyName_tblController : Controller
    {
        private CompanyCaptureDBEntities1 db = new CompanyCaptureDBEntities1();

        // GET: CompanyName_tbl
        public ActionResult Index()
        {
            var companyName_tbl = db.CompanyName_tbl.Include(c => c.BusinessSector_tbl).Include(c => c.CompanyType_tbl).Include(c => c.Exchange_tbl);
            return View(companyName_tbl.ToList());
        }

        //GET: CompanyName_tbl populate Table view
        public ActionResult PopulateTable()
        {
            //CompanyCaptureDBEntities1 database = new CompanyCaptureDBEntities1();
            return View(from CompanyName_tbl in db.CompanyName_tbl
                        select CompanyName_tbl);
            
        }

        // GET: CompanyName_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyName_tbl companyName_tbl = db.CompanyName_tbl.Find(id);
            if (companyName_tbl == null)
            {
                return HttpNotFound();
            }
            return View(companyName_tbl);
        }
       

        // GET: CompanyName_tbl/Create
        public ActionResult Create(string searchBy, string list)
        {
            var comList = new List<string>();
            var comQuery = from com in db.CompanyName_tbl
                              select com.companyName;
            comList.AddRange(comQuery.Distinct());

            /////////////////////////////////////////////////////////////

            IList<CompanyName_tbl> comNameList = new List<CompanyName_tbl>();
            var co = from k in db.CompanyName_tbl select k;

            //////////////////////////////////////////////////////////

            var li = new object[] { "Exchange", "Business Sector", "Country", "Company Name" };

            ViewBag.list = new SelectList(li);

            //////////////////////////////////////////////////////////////

            if (!String.IsNullOrEmpty(searchBy))
            {
                co = co.Where(s => s.companyName.Contains(searchBy));
            }

            var requiredList = co.ToList();


            if (li.Equals("Company Name"))
            {
                if (!String.IsNullOrEmpty(searchBy))
                {
                    co = co.Where(s => s.companyName.Contains(searchBy));
                }
            }
            //if (li.Equals("Country"))
            //{
            //    if (!String.IsNullOrEmpty(searchBy))
            //    {
                    
            //        companyName = db.Country_tbl.Where(a => a.countryName.Contains(searchBy));
            //    }
            //}
            if (li.Equals("Exchange"))
            {
                if (!String.IsNullOrEmpty(searchBy))
                {
                    return View(db.CompanyName_tbl.Where(s => s.exchangeCodeID == searchBy || searchBy == null).ToList());
                }
            }
            if (li.Equals("Business Sector"))
            {
                if (!String.IsNullOrEmpty(searchBy))
                {
                    return View(db.BusinessSector_tbl.Where(s => s.businessSectorDesc == searchBy || searchBy == null).ToList());
                }
            }
            return View(db.CompanyName_tbl.Where(s => s.companyName==searchBy || searchBy == null).ToList());


        }

        // POST: CompanyName_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "companyID,companyName,shortCode,corpInfo,updateDate,countryID,exchangeCodeID,companyTypeID,businessSectorID")] CompanyName_tbl companyName_tbl)
        {
            if (ModelState.IsValid)
            {
                db.CompanyName_tbl.Add(companyName_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.businessSectorID = new SelectList(db.BusinessSector_tbl, "businessSectorID", "businessSectorDesc", companyName_tbl.businessSectorID);
            ViewBag.companyTypeID = new SelectList(db.CompanyType_tbl, "companyTypeID", "companyTypeDesc", companyName_tbl.companyTypeID);
            ViewBag.exchangeCodeID = new SelectList(db.Exchange_tbl, "exchangeCodeID", "exchangeName", companyName_tbl.exchangeCodeID);
            return View(companyName_tbl);
        }

        // GET: CompanyName_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyName_tbl companyName_tbl = db.CompanyName_tbl.Find(id);
            if (companyName_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.businessSectorID = new SelectList(db.BusinessSector_tbl, "businessSectorID", "businessSectorDesc", companyName_tbl.businessSectorID);
            ViewBag.companyTypeID = new SelectList(db.CompanyType_tbl, "companyTypeID", "companyTypeDesc", companyName_tbl.companyTypeID);
            ViewBag.exchangeCodeID = new SelectList(db.Exchange_tbl, "exchangeCodeID", "exchangeName", companyName_tbl.exchangeCodeID);
            return View(companyName_tbl);
        }

        // POST: CompanyName_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "companyID,companyName,shortCode,corpInfo,updateDate,countryID,exchangeCodeID,companyTypeID,businessSectorID")] CompanyName_tbl companyName_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyName_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.businessSectorID = new SelectList(db.BusinessSector_tbl, "businessSectorID", "businessSectorDesc", companyName_tbl.businessSectorID);
            ViewBag.companyTypeID = new SelectList(db.CompanyType_tbl, "companyTypeID", "companyTypeDesc", companyName_tbl.companyTypeID);
            ViewBag.exchangeCodeID = new SelectList(db.Exchange_tbl, "exchangeCodeID", "exchangeName", companyName_tbl.exchangeCodeID);
            return View(companyName_tbl);
        }

        // GET: CompanyName_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyName_tbl companyName_tbl = db.CompanyName_tbl.Find(id);
            if (companyName_tbl == null)
            {
                return HttpNotFound();
            }
            return View(companyName_tbl);
        }

        // POST: CompanyName_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyName_tbl companyName_tbl = db.CompanyName_tbl.Find(id);
            db.CompanyName_tbl.Remove(companyName_tbl);
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
