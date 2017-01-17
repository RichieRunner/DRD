using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Richie.DRD.Models
{
    public class Majors
    {
        public int TeamPID { get; set; }

        [Display(Name="Player")]
        public string Player { get; set; }

        [Display(Name="Team")]
        public string TeamName { get; set; }
    }
}