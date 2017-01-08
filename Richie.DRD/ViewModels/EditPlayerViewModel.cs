using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Richie.DRD.Models;
using System.Web.Mvc;

namespace Richie.DRD.ViewModels
{
    public class EditPlayerViewModel
    {
        public Player Player { get; set; }

        public Position Position { get; set; }

        public MLBTeam MLBTeam { get; set; }
        public List<SelectListItem> Positions { get; set; }
        public List<SelectListItem> MLBTeams { get; set; }
        public EditPlayerViewModel(Player player)
        {
            Player = player;
        }

    }
}