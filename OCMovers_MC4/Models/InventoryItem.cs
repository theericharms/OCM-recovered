using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OCMovers_MC4.Models
{
	public class InventoryItem
	{
		public int InventoryItemID { get; set; }

		[Display(Name="Item Name")]
        [Required]
		public string inventoryItem { get; set; }

		public Room Room { get; set; }

        public int Seed { get; set; }

        public string test { get; set; }
	}
}