using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Richie.DRD.Models;

namespace Richie.DRD.Repository
{
    public interface ILookUpDataRepository
    {
        LookUpItem getPositions();

        LookUpItem getMLBTeams();
        
        LookUpItem getTeams();


    }
}