using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCMovers_MC4.Models
{
    public class CustomerEstimates
    {
        [Key]
        public int CustomerEstimatesId { get; set; }

        public DateTime CreateDate { get; set; }

        public int EstimateId { get; set; }

        public string IntroText { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        [Display(Name = "Possible Move Date")]
        public DateTime MoveDate { get; set; }

        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; }

        [Display(Name = "Arrival Text")]
        public string ArrivalText { get; set; }

        [Display(Name = "Hourly Rate Text")]
        public string HourlyRateText { get; set; }

        [Display(Name = "Travel Time Text")]
        public string TravelTimeText { get; set; }

        public string Fuel { get; set; }
        public string Tolls { get; set; }

        [Display(Name = "Parking Permits")]
        public string ParkingPermits { get; set; }

        [Display(Name = "Hours Estimate")]
        public string HoursEstimate { get; set; }

        [Display(Name = "Total Estimate")]
        public string TotalEstimate { get; set; }

        [Display(Name = "Read our policies")]
        public string ReadPoliciesText { get; set; }

        [Display(Name = "Parking Permits")]
        public string ParkingPermitsText { get; set; }

        [Display(Name = "Responsible")]
        public string ResponsibleText { get; set; }

        [Display(Name = "Elevators")]
        public string ElevatorText { get; set; }

        [Display(Name = "Mattress Covers")]
        public string MattressCoverText { get; set; }

        [Display(Name = "Storms")]
        public string StormText { get; set; }

        [Display(Name = "Cancellation")]
        public string CancellationText { get; set; }

        [Display(Name = "Travel Time Text")]
        public string PaymentsText { get; set; }

        [Display(Name = "OCM Representative Name")]
        public string RepName { get; set; }
    }
}
