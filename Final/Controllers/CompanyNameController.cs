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
    public class CompanyNameController : Controller
    {
        private CompanyCaptureDBEntities2 db = new CompanyCaptureDBEntities2();

        // GET: CompanyName
        public ActionResult Index()
        {
            var companyName_tbl = db.CompanyName_tbl.Include(c => c.BusinessSector_tbl).Include(c => c.CompanyType_tbl).Include(c => c.Exchange_tbl);
            return View(companyName_tbl.ToList());
        }
        public ActionResult Search(string searchBy, string list)
        {

            ///////////////////////////////////////////////////////////////   Drop down population                 /////////////////////////////////////////////////

            var ola = new object[] { "Exchange", "Business Sector", "Country", "Company Name" };
            ViewBag.list = new SelectList(ola);

            //////////////////////////////////////////  Creating a Query for Company Name //////////////////////////////////////////////////////////////////////////
            //            var comList = new List<string>();
            //            var comQuery = from com in db.CompanyName_tbl
            //                           select com.companyName;
            //            comList.AddRange(comQuery.Distinct());

            //            /////////////////////////////  Creating a Query for Exchange Name ///////////////////////////////
            //            var exList = new List<string>();
            //            var exQuery = from ex in db.Exchange_tbl
            //                           select ex.exchangeCodeID;
            //            exList.AddRange(exQuery.Distinct());

            //            /////////////////////////////  Creating a Query for country Name ///////////////////////////////
            //            var couList = new List<string>();
            //            var couQuery = from cou in db.Country_tbl
            //                           select cou.countryName;
            //            couList.AddRange(couQuery.Distinct());

            //            /////////////////////////////  Creating a Query for Business Sector Name ///////////////////////////////
            //            var busList = new List<string>();
            //            var busQuery = from bus in db.BusinessSector_tbl
            //                           select bus.businessSectorDesc;
            //            busList.AddRange(busQuery.Distinct());

            /////////////////////////////////////////////////////////   Creating a list of all queried Com name     //////////////////////////////////////////////////////////

            //            IList<CompanyName_tbl> comNameList = new List<CompanyName_tbl>();
            //            var co = from k in db.CompanyName_tbl select k;

            //            IList<Country_tbl> couNameList = new List<Country_tbl>();
            //            var c = from g in db.Country_tbl select g;


            //            IList<Exchange_tbl> exNameList = new List<Exchange_tbl>();
            //            var e = from f in db.Exchange_tbl select f;

            //            IList<BusinessSector_tbl> BusNameList = new List<BusinessSector_tbl>();
            //            var b = from r in db.BusinessSector_tbl select r;


            //////////////////////////////////////////////////  ViewBags   /////////////////////////////////////////////////////////////////////////////////////


            ViewBag.companyNameID = new SelectList(db.CompanyName_tbl, "companyID", "companyName");
            ViewBag.businessSectorID = new SelectList(db.BusinessSector_tbl, "businessSectorID", "businessSectorDesc");
            ViewBag.companyTypeID = new SelectList(db.CompanyType_tbl, "companyTypeID", "companyTypeDesc");
            ViewBag.exchangeCodeID = new SelectList(db.Exchange_tbl, "exchangeCodeID", "exchangeName");

            //////////////////////////////////////////////////////////////


            var comName = from g in db.CompanyName_tbl
                          select g;

            if (!String.IsNullOrEmpty(searchBy))
            {


                if (list.Equals("Company Name"))
                {


                    comName = comName.Where(s => s.companyName.Contains(searchBy));
                }



                if (list.Equals("Exchange"))
                {

                    comName = comName.Where(s => s.exchangeCodeID.Contains(searchBy));
                }



                if (list.Equals("Business Sector"))
                {

                    comName = comName.Where(s => s.BusinessSector_tbl.businessSectorDesc.Contains(searchBy));
                }
                if (list.Equals("Country"))
                {

                    var countries = db.Country_tbl.ToList();
                    List<int> countryIds = countries.Where(x => x.countryName.ToLower().Contains(searchBy.ToLower())).Select(x => x.countryID).ToList();
                    List<int> companyIds = db.countrycompviews.Where(x => countryIds.Contains(x.countryID)).Select(x => x.companyID).ToList();
                    comName = comName.Where(s => companyIds.Contains(s.companyID));

                }

            }
            else
            {
                return View(comName.ToList());
            }
            return View(comName);

        }
        // GET: CompanyName/Details/5
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

        // GET: CompanyName/Create
        public ActionResult Create()
        {
            ViewBag.businessSectorID = new SelectList(db.BusinessSector_tbl, "businessSectorID", "businessSectorDesc");
            ViewBag.companyTypeID = new SelectList(db.CompanyType_tbl, "companyTypeID", "companyTypeDesc");
            ViewBag.exchangeCodeID = new SelectList(db.Exchange_tbl, "exchangeCodeID", "exchangeName");
            return View();
        }

        // POST: CompanyName/Create
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

        // GET: CompanyName/Edit/5
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

        // POST: CompanyName/Edit/5
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

        // GET: CompanyName/Delete/5
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

        // POST: CompanyName/Delete/5
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
