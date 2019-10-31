using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMovers_MC4.DAL;

namespace OCMovers_MC4.Models
{
	public class User
	{
		public int ID { get; set; }
		//public int RoleID { get; set; }
		public string Name { get; set; }
		public string UserName { get; set ;}
		public string Password { get; set; }
		public string Email { get; set; }
		//public virtual Role Role { get; set; }
	}
}