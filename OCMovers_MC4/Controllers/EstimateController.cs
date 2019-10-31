using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using OCMovers_MVC4.Mailers;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;
using OCMovers_MC4.ViewModel;

namespace OCMovers_MC4.Controllers
{
    public class EstimateController : Controller
    {
        //
        // GET: /Estimate Controller/

        private OCMovers_MVC4Context db = new OCMovers_MVC4Context();


        public ActionResult Index()
        {
#if DEBUG
            ViewBag.Debug = "true";
#else
                ViewBag.Debug = null;
#endif

            //ViewBag.InventoryItems = db.InventoryItem.ToList();

            //var roomL = db.Room.ToList().OrderBy(r => r.RoomID);

            @ViewBag.Title = "Old City Movers Estimate | A Philadelphia, PA insured & bonded moving company";

            @ViewBag.Description = "Use Old City Mover's Estimate Form to plan your move";

            @ViewBag.Keywords = "Moving company, movers, residential, home, storage, warehouse, commercial, furniture, Philadelphia movers, New York movers, Delaware movers, New Jersey Movers";


           // ViewBag.InventoryItems = db.InventoryItem.Include("Room").ToList().OrderBy(x => x.inventoryItem);

            //ViewBag.roomList = db.Room.ToList().OrderBy(r => r.RoomID);

            //ViewBag.inventoryCount = db.InventoryItem.Count();

            OCMovers_MC4.ViewModel.EstimateForm estimateForm = new OCMovers_MC4.ViewModel.EstimateForm();

            //return View(db.InventoryItems.ToList());
            return View(estimateForm);
        }

        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

        public ActionResult GetAddressForm()
        {
            var model = new Address();
            return PartialView(VirtualPathUtility.ToAbsolute("~/Views/Estimate/_addAddress.cshtml"), model);
        }

        public ActionResult GetAddressFormType(string type)
        {
            var form = string.Empty;

            switch (type)
            {
                case "House":
                    form = "_address-house.cshtml";
                    break;

                case "Apartment":
                    form = "_address-apartment.cshtml";
                    break;

                case "Office":
                    form = "_address-office.cshtml";
                    break;

                case "Storage-Unit":
                    form = "_address-storage.cshtml";
                    break;
            }

            var filename = string.Concat("~/Views/Estimate/", form);

            var model = new Address();
            return PartialView(VirtualPathUtility.ToAbsolute(filename), model);
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SendEstimate(OCMovers_MC4.ViewModel.EstimateForm estimateForm, List<Address> addresses, List<EstimateFormInventory> model = null)
        {

            Console.WriteLine(addresses);

            try
            {
                if (ModelState.IsValid)
                {
                    Guid EG = Guid.NewGuid();

                    estimateForm.EstimateGuid = EG;

                    OCMovers_MC4.Models.EstimateForm newEstimate = new OCMovers_MC4.Models.EstimateForm()
                    {
                        EstimateGuid = EG,
                        Feedback = estimateForm.Feedback,
                        InventoryWriteIn = estimateForm.InventoryWriteIn,
                        InventoryItem = estimateForm.InventoryItem,
                        IsDateFlexible = estimateForm.IsDateFlexible,
                        PreviousCustomer = estimateForm.PreviousCustomer,
                        PreviousCustomerName = estimateForm.PreviousCustomerName,
                        agreeCorrect = estimateForm.agreeCorrect,
                        email = estimateForm.email,
                        estBoxCount = estimateForm.estBoxCount,
                        moveDateEnd = estimateForm.moveDateEnd,
                        moveDescription = estimateForm.moveDescription,
                        name = estimateForm.name,
                        packingServices = estimateForm.packingServices,
                        phone = estimateForm.phone,

                        // old fields not required here
                        dwellingTypeCurrent = estimateForm.dwellingTypeCurrent,
                        dwellingTypeCurrentFloorApt = estimateForm.dwellingTypeCurrentFloorApt,
                        dwellingTypeCurrentFloorHouse = estimateForm.dwellingTypeCurrentFloorHouse,
                        dwellingTypeDestination = estimateForm.dwellingTypeDestination,
                        dwellingTypeDestinationFloorApt = estimateForm.dwellingTypeDestinationFloorApt,
                        dwellingTypeDestinationFloorHouse = estimateForm.dwellingTypeDestinationFloorHouse,
                        loc1BuildingName = estimateForm.loc1BuildingName,
                        loc1Address1 = estimateForm.loc1Address1,
                        loc1Address2 = estimateForm.loc1Address2,
                        loc1Apartment = estimateForm.loc1Apartment,
                        loc1City = estimateForm.loc1City,
                        loc1State = estimateForm.loc1State,
                        loc1Postal = estimateForm.loc1Postal,
                        loc2BuildingName = estimateForm.loc2BuildingName,
                        loc2Address1 = estimateForm.loc2Address1,
                        loc2Address2 = estimateForm.loc2Address2,
                        loc2Apartment = estimateForm.loc2Apartment,
                        loc2City = estimateForm.loc2City,
                        loc2State = estimateForm.loc2State,
                        loc2Postal = estimateForm.loc2Postal,
                        elevStairsCurrent = estimateForm.elevStairsCurrent,
                        elevStairsDestination = estimateForm.elevStairsDestination,
                        elevStairsResExp = estimateForm.elevStairsResExp,
                        stairsToFrontExp = estimateForm.stairsToFrontExp,
                        longWalksToDoorExp = estimateForm.longWalksToDoorExp,
                        specialCareItemExp = estimateForm.specialCareItemExp,
                        //Addresses = new List<Address>(),
                        elevStairsRes = estimateForm.elevStairsRes,
                        longWalksToDoor = estimateForm.longWalksToDoor,
                        numRoomsCurrent = estimateForm.numRoomsCurrent,
                        numRoomsDestination = estimateForm.numRoomsDestination,
                        specialCareItem = estimateForm.specialCareItem,
                        stairsToFront = estimateForm.stairsToFront,
                        submitDate = DateTime.Now
                    };

                    db.EstimateForm.Add(newEstimate);
                    db.SaveChanges();

                    //foreach (var a in addresses)
                    //{
                    //    var newAddress = new CustomerAddress()
                    //    {
                    //        AddressType = a.AddressType,
                    //        Address1 = a.Address1,
                    //        AptNum = a.AptNum,
                    //        BuildingName = a.BuildingName,
                    //        City = a.City,
                    //        EstimateId = newEstimate.EstimateFormID,
                    //        Postcode = a.Postcode,
                    //        State = a.State,
                    //        AptFloor = a.AptFloor ?? 0,
                    //        ElevatorStairs = a.ElevatorStairs,
                    //        ElevatorStairsDescription = a.ElevatorStairsDescription,
                    //        HouseOrApt = a.HouseOrApt,
                    //        HouseStories = a.HouseStories,
                    //        Inventory = a.Inventory,
                    //        LongWalks = a.LongWalks,
                    //        LongWalksDescription = a.LongWalksDescription,
                    //        Notes = a.Notes,
                    //        NumberOfBedrooms = a.NumberOfBedrooms,
                    //        SpecialCare = a.SpecialCare,
                    //        SpecialCareDescription = a.SpecialCareDescription,
                    //        Stairs = a.Stairs,
                    //        StairsDescription = a.StairsDescription,
                    //        BoxCount = a.BoxCount
                    //    };

                    //    db.CustomerAddress.Add(newAddress);
                    //    db.SaveChanges();
                    //}

                    //newEstimate.Addresses = addresses;

                    UserMailer.Welcome(newEstimate).Send();

                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = "success" }
                    };

                }
                else
                {
                    var es = ModelState.Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();

                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();
                    Debug.WriteLine("Model state not valid");

                    StringBuilder sb = new StringBuilder();

                    foreach (var c in errors)
                    {
                        sb.Append(string.Concat(c.Key, ": ", c.Errors[0].ErrorMessage, "<br>"));
                    }

                    string output = sb.ToString();

                    CreateErrorLogEmail(output, null);

                    UserMailer.SendModelStateError(output).Send();

                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = output }
                    };
                    ;
                }
            }
            catch (Exception ex)
            {
                var str = new JavaScriptSerializer().Serialize(estimateForm);

                CreateErrorLogEmail(str, ex);

                throw;
            }
        }

        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public JsonResult SendEstimate(OCMovers_MC4.ViewModel.EstimateForm estimateForm,  List<Address> addresses, List<EstimateFormInventory> model = null)
        //        {

        //            Console.WriteLine(addresses);

        //            try
        //            {
        //                if (ModelState.IsValid)
        //                {
        //                    Guid EG = Guid.NewGuid();

        //                    estimateForm.EstimateGuid = EG;

        //                    OCMovers_MC4.Models.EstimateForm newEstimate = new OCMovers_MC4.Models.EstimateForm()
        //                    {
        //                        EstimateGuid = EG,
        //                        Feedback = estimateForm.Feedback,
        //                        InventoryWriteIn = estimateForm.InventoryWriteIn,
        //                        InventoryItem = estimateForm.InventoryItem,
        //                        IsDateFlexible = estimateForm.IsDateFlexible,
        //                        PreviousCustomer = estimateForm.PreviousCustomer,
        //                        PreviousCustomerName = estimateForm.PreviousCustomerName,
        //                        agreeCorrect = estimateForm.agreeCorrect,
        //                        email = estimateForm.email,
        //                        estBoxCount = estimateForm.estBoxCount,
        //                        moveDateEnd = estimateForm.moveDateEnd,
        //                        moveDescription = estimateForm.moveDescription,
        //                        name = estimateForm.name,
        //                        packingServices = estimateForm.packingServices,
        //                        phone = estimateForm.phone,

        //                        // old fields not required here
        //                        dwellingTypeCurrent = "nothing",
        //                        dwellingTypeCurrentFloorApt = "nothing",
        //                        dwellingTypeCurrentFloorHouse = "nothing",
        //                        dwellingTypeDestination = "nothing",
        //                        dwellingTypeDestinationFloorApt = "nothing",
        //                        dwellingTypeDestinationFloorHouse = "nothing",
        //                        loc1BuildingName = "nothing",
        //                        loc1Address1 = "nothing",
        //                        loc1Address2 = "nothing",
        //                        loc1Apartment = "nothing",
        //                        loc1City = "nothing",
        //                        loc1State = "nothing",
        //                        loc1Postal = "nothing",
        //                        loc2BuildingName = "nothing",
        //                        loc2Address1 = "nothing",
        //                        loc2Address2 = "nothing",
        //                        loc2Apartment = "nothing",
        //                        loc2City = "nothing",
        //                        loc2State = "nothing",
        //                        loc2Postal = "nothing",
        //                        elevStairsCurrent = "nothing",
        //                        elevStairsDestination = "nothing",
        //                        elevStairsResExp = "nothing",
        //                        stairsToFrontExp = "nothing",
        //                        longWalksToDoorExp = "nothing",
        //                        specialCareItemExp = "nothing",
        //                        Addresses = new List<Address>(),
        //                        elevStairsRes = false,
        //                        longWalksToDoor = false,
        //                        numRoomsCurrent = 0,
        //                        numRoomsDestination = 0,
        //                        specialCareItem = false,
        //                        stairsToFront = false,
        //                        submitDate = DateTime.Now
        //                    };

        //                    db.EstimateForm.Add(newEstimate);
        //                    db.SaveChanges();

        //                    foreach (var a in addresses)
        //                    {
        //                        var newAddress = new CustomerAddress()
        //                        {
        //                            AddressType = a.AddressType,
        //                            Address1 = a.Address1,
        //                            AptNum = a.AptNum,
        //                            BuildingName = a.BuildingName,
        //                            City = a.City,
        //                            EstimateId = newEstimate.EstimateFormID,
        //                            Postcode = a.Postcode,
        //                            State = a.State,
        //                            AptFloor = a.AptFloor ?? 0,
        //                            ElevatorStairs = a.ElevatorStairs,
        //                            ElevatorStairsDescription = a.ElevatorStairsDescription,
        //                            HouseOrApt = a.HouseOrApt,
        //                            HouseStories = a.HouseStories,
        //                            Inventory = a.Inventory,
        //                            LongWalks = a.LongWalks,
        //                            LongWalksDescription = a.LongWalksDescription,
        //                            Notes = a.Notes,
        //                            NumberOfBedrooms = a.NumberOfBedrooms,
        //                            SpecialCare = a.SpecialCare,
        //                            SpecialCareDescription = a.SpecialCareDescription,
        //                            Stairs = a.Stairs,
        //                            StairsDescription = a.StairsDescription,
        //                            BoxCount = a.BoxCount
        //                        };

        //                        db.CustomerAddress.Add(newAddress);
        //                        db.SaveChanges();
        //                    }

        //                    newEstimate.Addresses = addresses;

        //                    UserMailer.Welcome(newEstimate).Send();

        //                    return new JsonResult()
        //                    {
        //                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
        //                        Data = new { result = "success" }
        //                    };

        //                }
        //                else
        //                {
        //                    var es = ModelState.Where(x => x.Value.Errors.Count > 0)
        //                        .Select(x => new { x.Key, x.Value.Errors })
        //                        .ToArray();

        //                    var errors = ModelState
        //                        .Where(x => x.Value.Errors.Count > 0)
        //                        .Select(x => new { x.Key, x.Value.Errors })
        //                        .ToArray();
        //                    Debug.WriteLine("Model state not valid");

        //                    StringBuilder sb = new StringBuilder();

        //                    foreach (var c in errors)
        //                    {
        //                        sb.Append(string.Concat(c.Key, ": ", c.Errors[0].ErrorMessage, "<br>"));
        //                    }

        //                    string output = sb.ToString();

        //                    CreateErrorLogEmail(output, null);

        //                    UserMailer.SendModelStateError(output).Send();

        //                    return new JsonResult()
        //                    {
        //                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
        //                        Data = new { result = output }
        //                    };
        //;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                var str = new JavaScriptSerializer().Serialize(estimateForm);

        //                CreateErrorLogEmail(str, ex);

        //                throw;
        //            }
        //        }

        public void CreateErrorLogEmail(string str, Exception ex)
        {
            JObject parsed = JObject.Parse(str);

            StringBuilder sb = new StringBuilder();

            if (ex != null)
            {
                sb.Append(string.Concat(ex.Message, "<br>"));
                sb.Append(string.Concat(ex, "<br>"));
            }

            sb.Append("<ul>");

            foreach (var pair in parsed)
            {
                if (pair.Key != "RoomList" && pair.Key != "InventoryItem")
                {
                    if (!String.IsNullOrEmpty(pair.Value.ToString()))
                    {
                        sb.Append(string.Format("{0}{1} : {2}{3}", "<li>", pair.Key, pair.Value, "</li>"));
                    }
                    else
                    {
                        sb.Append(string.Format("{0}{1} : {2}{3}", "<li style='color:red'>", pair.Key, pair.Value, "</li>"));
                    }

                }

            }

            sb.Append("</ul>");

            string output = sb.ToString();

            Debug.WriteLine(output);

            UserMailer.SendErrorLog(output).Send();
        }

        public ActionResult Thanks()
        {
            @ViewBag.Title = "Old City Movers Estimate | A Philadelphia, PA insured & bonded moving company";

            @ViewBag.Description = "Use Old City Mover's Estimate Form to plan your move";

            @ViewBag.Keywords = "Moving company, movers, residential, home, storage, warehouse, commercial, furniture, Philadelphia movers, New York movers, Delaware movers, New Jersey Movers";

            var content = db.Content.Find(1);

            return View(content);
        }

    }
}
