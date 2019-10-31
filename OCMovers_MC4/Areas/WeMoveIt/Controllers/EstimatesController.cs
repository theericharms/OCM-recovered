using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCMovers_MC4.Models;
using OCMovers_MC4.DAL;
using OCMovers_MC4.ViewModel;
using PagedList;

namespace OCMovers_MC4.Areas.WeMoveIt.Controllers
{
    [Authorize]
    public class EstimatesController : Controller
    {
        private readonly OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        //
        // GET: /Administration/Estimates/s

        public ViewResult Index(int? page)
        {
            var estimateList = db.EstimateForm.OrderByDescending(x => x.EstimateFormID).ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var estPages = estimateList.ToPagedList(pageNumber, 35); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = estPages;

            return View(estimateList);
        }

        [HttpPost]
        public ActionResult Index(int? page, string searchTerm, string dateFrom, string dateTo)
        {
            var estimateList = db.EstimateForm.OrderByDescending(x => x.EstimateFormID).ToList();
            
            if (searchTerm != "" && dateFrom == "" && dateTo == "")
            {
                estimateList = estimateList.Where(x => x.name.Contains(searchTerm) || x.phone.Contains(searchTerm) || x.email.Contains(searchTerm)).ToList();
            }

            if (dateFrom != "" && dateTo != "" && searchTerm == "")
            {
                //var thisDateFrom = Convert.ToDateTime(dateFrom);
                //var thisDateTo = Convert.ToDateTime(dateTo).Date;

                estimateList = estimateList.Where(x => x.submitDate.Date >= Convert.ToDateTime(dateFrom).Date && x.submitDate.Date <= Convert.ToDateTime(dateTo).Date).ToList();

            }

            else if (dateFrom != "" && dateTo == "" && searchTerm == "")
            {
                estimateList = estimateList.Where(x => x.submitDate.Date >= Convert.ToDateTime(dateFrom).Date).ToList();
            }

            else if (dateFrom == "" && dateTo != "" && searchTerm == "")
            {
                estimateList = estimateList.Where(x => x.submitDate.Date <= Convert.ToDateTime(dateTo).Date).ToList();
            }
            else if (searchTerm != "" && dateFrom != "" && dateTo != "")
            {
                estimateList = estimateList.Where(x => x.submitDate.Date >= Convert.ToDateTime(dateFrom).Date && x.submitDate.Date <= Convert.ToDateTime(dateTo).Date && ((x.name.Contains(searchTerm) || x.phone.Contains(searchTerm) || x.email.Contains(searchTerm)))).ToList();

            }

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var estPages = estimateList.ToPagedList(pageNumber, 15); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = estPages;

            return View(estimateList);
        }

        //
        // GET: /Administration/Estimates/Details/5
        //[HttpGet]
        //public ViewResult Details(int id)
        //{
        //    var hasEstimate = db.CustomerEstimates.FirstOrDefault(x => x.EstimateId == id) != null;

        //    var estimateform = db.EstimateForm.Find(id);
        //    var inventoryList = db.EstimateFormInventory.Include("efRoom").Include("efInvItem").Where(x => x.efEstimateGuid == estimateform.EstimateGuid).ToList();
        //    int? customerEstimateId = null;

        //    var firstOrDefault = db.CustomerEstimates.FirstOrDefault(x => x.EstimateId == estimateform.EstimateFormID);
        //    if (firstOrDefault != null)
        //    {
        //        customerEstimateId = firstOrDefault.CustomerEstimatesId;
        //    }

        //    var model = new EstimateDetail()
        //    {
        //        Estimateform = estimateform,
        //        InventoryList = inventoryList,
        //        HasEstimate = hasEstimate,
        //        CustomerEstimateId = (int?)customerEstimateId
        //    };

        //    return View(model);
        //}

        //
        // GET: /Administration/Estimates/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administration/Estimates/Create

        //[HttpPost]
        //public ActionResult Create(OCMovers_MC4.ViewModel.EstimateForm estimateform, List<Address> addresses )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EstimateForm.Add(estimateform);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(estimateform);
        //}

        //
        // GET: /Administration/Estimates/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    OCMovers_MC4.Models.EstimateForm estimateform = db.EstimateForm.Find(id);
        //    return View(estimateform);
        //}

        //
        // POST: /Administration/Estimates/Edit/5

        //[HttpPost]
        //public ActionResult Edit(OCMovers_MC4.ViewModel.EstimateForm estimateform)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(estimateform).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(estimateform);
        //}

        //
        // GET: /Administration/Estimates/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    OCMovers_MC4.Models.EstimateForm estimateform = db.EstimateForm.Find(id);
        //    return View(estimateform);
        //}

        public ActionResult CreateCustomerEstimate()
        {
            var estId = Convert.ToInt32(RouteData.Values["id"]);
            OCMovers_MC4.Models.EstimateForm est = db.EstimateForm.FirstOrDefault(x => x.EstimateFormID == estId);

            var startAddress2 = !string.IsNullOrEmpty(est.loc1Address2) ? ", " + est.loc1Address2 : string.Empty;
            var endAddress2 = !string.IsNullOrEmpty(est.loc2Address2) ? ", " + est.loc2Address2 : string.Empty;

            var startApt = !string.IsNullOrEmpty(est.loc1Apartment) ? string.Concat(est.loc1Apartment, ", ") : string.Empty;
            var endApt = !string.IsNullOrEmpty(est.loc2Apartment) ? string.Concat(est.loc2Apartment, ", ") : string.Empty;

            var stairsElvStart = !string.IsNullOrEmpty(est.elevStairsCurrent)
                ? string.Concat(est.elevStairsCurrent) : string.Empty;
            var stairsElvEnd = !string.IsNullOrEmpty(est.elevStairsDestination)
                ? string.Concat(est.elevStairsDestination) : string.Empty;

            var startAddress = string.Concat(est.loc1Address1, startAddress2,", ", startApt, est.loc1City, ", ",
                est.loc1State, " ", est.loc1Postal);
            var endAddress = string.Concat(est.loc2Address1, endAddress2, ", ", endApt, est.loc2City, ", ",
               est.loc2State, " ", est.loc2Postal);

            var startFloor = est.dwellingTypeCurrent == "House" ? ", " + est.dwellingTypeCurrentFloorHouse : ", " +  est.dwellingTypeCurrentFloorApt.ToString();
            var endFloor = est.dwellingTypeCurrent == "House" ? ", " + est.dwellingTypeCurrentFloorHouse : ", " + est.dwellingTypeCurrentFloorApt.ToString();

            var startBuilding =
                !string.IsNullOrEmpty(est.loc1BuildingName) ? string.Concat(est.loc1BuildingName, ": ") : string.Empty;

            var endBuilding =
                !string.IsNullOrEmpty(est.loc2BuildingName) ? string.Concat(est.loc2BuildingName, ": ") : string.Empty;

            var start = string.Concat(startBuilding, startAddress, " (", est.dwellingTypeCurrent, startFloor, ") ", stairsElvStart);
            var end = string.Concat(endBuilding, endAddress, " (", est.dwellingTypeDestination, endFloor, ") ", stairsElvEnd);

            var model = new CreateCustomerEstimate()
            {
                EstimateFormId = est.EstimateFormID,
                CustomerName = est.name,
                PhoneNumber = est.phone,
                MoveDate = est.moveDateEnd,
                Start = start,
                End = end,
                CreateDate = DateTime.Now
            };

            return View(model);
        }

        public ActionResult EditCustomerEstimate()
        {
            var estId = Convert.ToInt32(RouteData.Values["id"]);
            var estimate = db.CustomerEstimates.FirstOrDefault(x => x.CustomerEstimatesId == estId);

            var model = new CreateCustomerEstimate()
            {
                CreateDate = estimate.CreateDate,
                Start = estimate.Start,
                End = estimate.End,
                CustomerEstimatesId = estimate.CustomerEstimatesId,
                EstimateFormId = estimate.EstimateId,
                ArrivalText = estimate.ArrivalText,
                ArrivalTime = estimate.ArrivalTime,
                CancellationText = estimate.CancellationText,
                CustomerName = estimate.CustomerName,
                ElevatorText = estimate.ElevatorText,
                Fuel = estimate.Fuel,
                HourlyRateText = estimate.HourlyRateText,
                HoursEstimate = estimate.HoursEstimate,
                IntroText = estimate.IntroText,
                MattressCoverText = estimate.MattressCoverText,
                MoveDate = estimate.MoveDate,
                ParkingPermits = estimate.ParkingPermits,
                ParkingPermitsText = estimate.ParkingPermitsText,
                PaymentsText = estimate.PaymentsText,
                PhoneNumber = estimate.PhoneNumber,
                ReadPoliciesText = estimate.ReadPoliciesText,
                ResponsibleText = estimate.ResponsibleText,
                StormText = estimate.StormText,
                Tolls = estimate.Tolls,
                TotalEstimate = estimate.TotalEstimate,
                TravelTimeText = estimate.TravelTimeText,
                RepName = estimate.RepName
            };

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SaveCustomerEstimate(CreateCustomerEstimate estimate)
        {
            var existing = db.CustomerEstimates.FirstOrDefault(x => x.EstimateId == estimate.EstimateFormId);

            if (existing != null)
            {
                existing.CreateDate = estimate.CreateDate;
                existing.Start = estimate.Start;
                existing.End = estimate.End;
                existing.CustomerEstimatesId = existing.CustomerEstimatesId;
                existing.EstimateId = estimate.EstimateFormId;
                existing.ArrivalText = estimate.ArrivalText;
                existing.ArrivalTime = estimate.ArrivalTime;
                existing.CancellationText = estimate.CancellationText;
                existing.CustomerName = estimate.CustomerName;
                existing.ElevatorText = estimate.ElevatorText;
                existing.Fuel = estimate.Fuel;
                existing.HourlyRateText = estimate.HourlyRateText;
                existing.HoursEstimate = estimate.HoursEstimate;
                existing.IntroText = estimate.IntroText;
                existing.MattressCoverText = estimate.MattressCoverText;
                existing.MoveDate = estimate.MoveDate;
                existing.ParkingPermits = estimate.ParkingPermits;
                existing.ParkingPermitsText = estimate.ParkingPermitsText;
                existing.PaymentsText = estimate.PaymentsText;
                existing.PhoneNumber = estimate.PhoneNumber;
                existing.ReadPoliciesText = estimate.ReadPoliciesText;
                existing.ResponsibleText = estimate.ResponsibleText;
                existing.StormText = estimate.StormText;
                existing.Tolls = estimate.Tolls;
                existing.TotalEstimate = estimate.TotalEstimate;
                existing.TravelTimeText = estimate.TravelTimeText;
                existing.RepName = estimate.RepName;

                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();
            }

            var model = new CustomerEstimates()
            {
                CreateDate = DateTime.Now,
                Start = estimate.Start,
                End = estimate.End,
                EstimateId = estimate.EstimateFormId,
                ArrivalText = estimate.ArrivalText,
                ArrivalTime = estimate.ArrivalTime,
                CancellationText = estimate.CancellationText,
                CustomerName = estimate.CustomerName,
                ElevatorText = estimate.ElevatorText,
                Fuel = estimate.Fuel,
                HourlyRateText = estimate.HourlyRateText,
                HoursEstimate = estimate.HoursEstimate,
                IntroText = estimate.IntroText,
                MattressCoverText = estimate.MattressCoverText,
                MoveDate = estimate.MoveDate,
                ParkingPermits = estimate.ParkingPermits,
                ParkingPermitsText = estimate.ParkingPermitsText,
                PaymentsText = estimate.PaymentsText,
                PhoneNumber = estimate.PhoneNumber,
                ReadPoliciesText = estimate.ReadPoliciesText,
                ResponsibleText = estimate.ResponsibleText,
                StormText = estimate.StormText,
                Tolls = estimate.Tolls,
                TotalEstimate = estimate.TotalEstimate,
                TravelTimeText = estimate.TravelTimeText,
                RepName = estimate.RepName
            };

            db.CustomerEstimates.Add(model);
            db.SaveChanges();

            return RedirectToAction("ViewCustomerEstimate", new {id = model.CustomerEstimatesId});
        }

        public ActionResult ViewCustomerEstimate()
        {
            var estId = Convert.ToInt32(RouteData.Values["id"]);
            CustomerEstimates model = db.CustomerEstimates.FirstOrDefault(x => x.CustomerEstimatesId == estId);

            return View(model);
        }

        //
        // POST: /Administration/Estimates/Delete/5

        [HttpPost, ActionName("DeleteEstimate")]
        public ActionResult DeleteConfirmed(int id)
        {
            OCMovers_MC4.Models.EstimateForm estimateform = db.EstimateForm.Find(id);
            db.EstimateForm.Remove(estimateform);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}