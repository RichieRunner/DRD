using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Richie.DRD.Models
{
    public class Player
    {
        public int PlayerPID { get; set; }

        public int MLBID { get; set; }
        public string BREFID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name="Name")]
        public string FullName { get; set; }

        public int YearDrafted { get; set; }

        public int TeamPID { get; set; }

        [Display(Name="Team")]
        public string TeamName { get; set; }


        public int PositionEID { get; set; }

        [Display(Name="Position")]
        public string PositionName { get; set; }


        public int MLBTeamID { get; set; }

        [Display(Name="MLB Team")]
        public string MLBTeamAbbreviation { get; set; }

        public DateTime MLBPromotionDate { get; set; }
        public DateTime DRDPromotionDate { get; set; }
        public DateTime DRDReleaseDate { get; set; }

        public string CurrentLevel { get; set; }

        public string Draft { get; set; }

        [Display(Name="MLB ABs")]
        public int ABs { get; set; }

        [Display(Name = "MLB IPs")]
        public decimal IPs { get; set; }

        [Display(Name = "MLB ABs/IPs")]
        public string RookieQualifier { get; set; }
        public bool HasLostRookieStatus { get; set; }
        public Int16 MLBOverallRanking { get; set; }


        ///Custom field
        ///

        public string NameTag
        {
            get
            {
                return FullName + " (" + MLBTeamAbbreviation + "-" + PositionName + ")";
            }
        }

    }
}