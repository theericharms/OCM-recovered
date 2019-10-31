using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OCMovers_MC4.Models
{
	public class EstimateFormInventory
	{
		[Key]
		public int efiID { get; set; }
		public Guid efEstimateGuid { get; set; }
		public Room efRoom { get; set; }

		public string customOrId { get; set; }

		public int Qty { get; set; }

		public int? efInvItemId { get; set; }
		public InventoryItem efInvItem { get; set; }
		public string CustomItem { get; set; }
	}
}