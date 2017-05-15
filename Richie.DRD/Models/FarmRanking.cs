using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Richie.DRD.Models
{
    public class FarmRanking
    {

        [Display(Name = "Rank")]
        public int RowNum { get; set; }

        public int TeamPID { get; set; }
        [Display(Name="Team")]
        public string TeamName { get; set; }
        [Display(Name = "Score")]
        public int RankingScore { get; set; }
        [Display(Name = "Count")]
        public int NumberOfRookiesInTop100 { get; set; }
        [Display(Name = "Prospects")]
        public string RookiesList { get; set; }


    }
}