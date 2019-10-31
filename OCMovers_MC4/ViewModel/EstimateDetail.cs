using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.ViewModel
{
    public class EstimateDetail
    {
        public EstimateForm Estimateform { get; set; }
        public List<EstimateFormInventory> InventoryList { get; set; }
        public bool HasEstimate { get; set; }
        public int? CustomerEstimateId { get; set; }
    }
}