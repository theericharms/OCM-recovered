using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.ViewModel
{
    public class EstimateForm
    {
        private DateTime _date = DateTime.Now;

        [Display(Name = "Submit Date")]
        public DateTime submitDate
        {
            get { return _date; }
            set { _date = value; }
        }

        //[Display(Name = "Start Move Date")]
        //[Required]
        //public DateTime moveDateStart { get; set; }

        [Display(Name = "Requested Date")]
        [Required]
        public DateTime moveDateEnd { get; set; }

        public bool IsDateFlexible { get; set; }

        public Guid EstimateGuid { get; set; }

        [Display(Name = "Brief Description of Move")]
        public string moveDescription { get; set; }

        [Display(Name = "Current Type")]
        public string dwellingTypeCurrent { get; set; }

        [Display(Name = "Current Apt Floor")]
        public string dwellingTypeCurrentFloorApt { get; set; }

        [Display(Name = "Current House Floor Number of Floors")]
        public string dwellingTypeCurrentFloorHouse { get; set; }

        [Display(Name = "Destination Type")]
        public string dwellingTypeDestination { get; set; }

        [Display(Name = "Destination Apt Floor")]
        public string dwellingTypeDestinationFloorApt { get; set; }

        [Display(Name = "Destination House Floor Number of Floors")]
        public string dwellingTypeDestinationFloorHouse { get; set; }

        [Display(Name = "Current Number of Rooms")]
        public int numRoomsCurrent { get; set; }

        [Display(Name = "Destination Number of Rooms")]
        public int numRoomsDestination { get; set; }

        [Display(Name = "Current Building Name")]
        public string loc1BuildingName { get; set; }

        [Display(Name = "Current Address 1")]
        public string loc1Address1 { get; set; }

        [Display(Name = "Current Address 2")]
        public string loc1Address2 { get; set; }

        [Display(Name = "Current Apartment")]
        public string loc1Apartment { get; set; }

        [Display(Name = "Current City")]
        public string loc1City { get; set; }

        [Display(Name = "Current State")]
        public string loc1State { get; set; }

        [Display(Name = "Current Postal Code")]
        public string loc1Postal { get; set; }

        [Display(Name = "Desination Building Name")]
        public string loc2BuildingName { get; set; }

        [Display(Name = "Desination Address 1")]
        public string loc2Address1 { get; set; }

        [Display(Name = "Desination Address 2")]
        public string loc2Address2 { get; set; }

        [Display(Name = "Desination Apartment")]
        public string loc2Apartment { get; set; }

        [Display(Name = "Desination City")]
        public string loc2City { get; set; }

        [Display(Name = "Desination State")]
        public string loc2State { get; set; }

        [Display(Name = "Desination Postal Code")]
        public string loc2Postal { get; set; }

        [Display(Name = "Elevator or Stairs at Current Location")]
        public string elevStairsCurrent { get; set; }

        [Display(Name = "Elevator or Stairs at Destination Location")]
        public string elevStairsDestination { get; set; }

        [Display(Name = "Storage type current location")]
        public string StorageTypeCurrent { get; set; }

        [Display(Name = "Storage type destination location")]
        public string StorageTypeDestination { get; set; }

        [Display(Name = "Storage type current location")]
        public string StorageGroundFloorAccessCurrent { get; set; }

        [Display(Name = "Storage type destination location")]
        public string StorageGroundFloorAccessDestination { get; set; }

        [Display(Name = "Other type current location")]
        public string OtherCurrent { get; set; }

        [Display(Name = "Other type destination location")]
        public string OtherDestination { get; set; }

        [Display(Name = "Stairs Restrictions")]
        public bool elevStairsRes { get; set; }

        [Display(Name = "Explanation")]
        public string elevStairsResExp { get; set; }

        [Display(Name = "Stairs to front door from Street")]
        public bool stairsToFront { get; set; }

        [Display(Name = "Explanation")]
        public string stairsToFrontExp { get; set; }

        [Display(Name = "Long walks to front door")]
        public bool longWalksToDoor { get; set; }

        [Display(Name = "Explanation")]
        public string longWalksToDoorExp { get; set; }

        [Display(Name = "Special Care Items")]
        public bool specialCareItem { get; set; }

        [Display(Name = "Explanation")]
        public string specialCareItemExp { get; set; }

        [Display(Name = "Estimated Box Count")]
        public string estBoxCount { get; set; }

        [Display(Name = "Agree Correct")]
        public bool agreeCorrect { get; set; }

        [Display(Name = "Inventory Write-in")]
        public string InventoryWriteIn { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string email { get; set; }

        [Display(Name = "Phone")]
        [DefaultValue(false)]
        [Required]
        public string phone { get; set; }

        [Required]
        public bool PreviousCustomer { get; set; }

        public String PreviousCustomerName { get; set; }

        public String Feedback { get; set; }

        public IList<Room> RoomList { get; set; }
        public IList<InventoryItem> InventoryItem { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

        public Address Address { get; set; }

        public bool packingServices { get; set; }
    }
}