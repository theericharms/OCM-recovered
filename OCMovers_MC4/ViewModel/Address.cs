using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMovers_MC4.ViewModel
{
    public class Address
    {
        public int EstimateId { get; set; }
        public string AddressType { get; set; }
        public string BuildingName { get; set; }
        public string Address1 { get; set; }
        public string AptNum { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }

        public string HouseOrApt { get; set; }
        public string HouseStories { get; set; }
        public int? AptFloor { get; set; }
        public string ElevatorStairs { get; set; }
        public string ElevatorStairsDescription { get; set; }
        public bool Stairs { get; set; }
        public string StairsDescription { get; set; }
        public bool LongWalks { get; set; }
        public string LongWalksDescription { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string Inventory { get; set; }
        public bool SpecialCare { get; set; }
        public string SpecialCareDescription { get; set; }
        public string Notes { get; set; }

        public string StorageType { get; set; }
        public bool StorageLongWalks { get; set; }
        public string StorageLongWalksDescription { get; set; }
        public string StorageGroundFloorElevator { get; set; }
        public bool ApartemntMultipleLevels { get; set; }
        public string ApartmentMultipleLevelsDescription { get; set; }
        public string BoxCount { get; set; }

        public Address()
        {
            Stairs = false;
            LongWalks = false;
            SpecialCare = false;
            StorageLongWalks = false;
            ApartemntMultipleLevels = false;
        }
    }

}