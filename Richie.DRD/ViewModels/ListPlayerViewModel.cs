using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Richie.DRD.Models;
using System.Web.Mvc;

namespace Richie.DRD.ViewModels
{
    public class ListPlayerViewModel
    {
        public Player Player { get; set; }
        public IEnumerable<Player> Players { get; set; }

        public Position Position { get; set; }
        public List<SelectListItem> Positions { get; set; }

        public ListPlayerViewModel()
        {

        }

    }
}