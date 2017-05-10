using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Richie.DRD.Models
{
    public class Team
    {
        public int TeamPID { get; set; }
        public string TeamName { get; set; }

        /// <summary>
        /// Custom field of Roster Size.
        /// </summary>
        public int RosterSize { get; set; }


        //public string OwnerName { get; set; }
        //public string OwnerEmail { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime StartDate { get; set; }

    }
}