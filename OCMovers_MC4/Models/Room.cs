using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OCMovers_MC4.Models
{
	public class Room
	{
		public int RoomID { get; set; }

		[Display(Name = "Room Name")]
        [Required]
		public string RoomName { get; set; }
		public IList<InventoryItem> InventoryItem { get; set; }
        public int Seed { get; set; }
	}
}