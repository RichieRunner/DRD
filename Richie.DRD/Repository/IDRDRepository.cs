﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Richie.DRD.Models;

namespace Richie.DRD.Repository
{
    interface IDRDRepository
    {
        
        Player GetPlayer(int id);
        IEnumerable<Player> ListPlayers(out int rosterSize, int id);
        IEnumerable<Player> GetData(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc);

        void EditPlayer(Player player);

        IEnumerable<Majors> ListMajors(out int rosterSize, int id);
        Team GetTeam(int id);
        DateTime GetLastUpdatedDate(out DateTime UpdatedDate);

        void PromotePlayer(int id);
        IEnumerable<FarmRanking> ListFarmRanking();
        List<Team> ListTeams();

    }
}
