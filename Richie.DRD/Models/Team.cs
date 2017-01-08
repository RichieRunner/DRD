using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Richie.DRD.Models
{
    public class Team
    {
        public int TeamPID { get; set; }
        public string TeamName { get; set; }

        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }

    }
}