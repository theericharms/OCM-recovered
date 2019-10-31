using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMovers_MC4.Models
{
    public class USStates
    {
        [Key]
        public int stateID { get; set; }
        public string stateName { get; set; }
        public string stateAbbr { get; set; }
    }
}