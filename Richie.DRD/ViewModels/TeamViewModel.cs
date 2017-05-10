using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Richie.DRD.Models;

namespace Richie.DRD.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public List<SelectListItem> Teams { get; set; }
        public List<Team> ListOfTeamObject { get; set; }
        public int RosterSize { get; set; }

    }
}