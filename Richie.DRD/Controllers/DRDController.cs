using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Richie.DRD.Models;
using Richie.DRD.Repository;
using Richie.DRD.ViewModels;

namespace Richie.DRD.Controllers
{
    public class DRDController : Controller
    {
        IDRDRepository drdRepo = new DRDRepository();
        ILookUpDataRepository lookUpRepo = new LookUpDataRepository();

        public ActionResult Index(int id = 17)
        {
            int rosterSize;
            DateTime updatedDate;

            var players = drdRepo.ListPlayers(out rosterSize, id);
            var team = drdRepo.GetTeam(id);
            var lastUpdatedDate = drdRepo.GetLastUpdatedDate(out updatedDate);

            ViewBag.TeamName = team;
            ViewBag.TeamPID = id;
            ViewBag.TeamRosterSize = rosterSize;
            ViewBag.LastUpdatedDate = lastUpdatedDate.ToString("MM/dd/yy");

            return View(players.ToList());
        }

        public ActionResult IndexMVCGrid()
        {
            
            return View();
        }

        public ActionResult GetTeamIndex()
        {
            // VM
            LookUpItem lookUpItem = lookUpRepo.getTeams();

            var teamVM = new TeamViewModel() { Teams = lookUpItem.DropDownList };
            return PartialView(@"~/Views/Shared/_TeamIndex.cshtml", teamVM);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Player player = drdRepo.GetPlayer(id);

            LookUpItem lookUpItem = lookUpRepo.getPositions();
            LookUpItem mlbTeamLookUpItem = lookUpRepo.getMLBTeams();

            var modelVM = new EditPlayerViewModel(player) { Positions = lookUpItem.DropDownList, MLBTeams = mlbTeamLookUpItem.DropDownList };

            return View(modelVM);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Player player = drdRepo.GetPlayer(id);

            LookUpItem positionLookUpItem = lookUpRepo.getPositions();
            LookUpItem mlbTeamLookUpItem = lookUpRepo.getMLBTeams();

            var modelVM = new EditPlayerViewModel(player) { Positions = positionLookUpItem.DropDownList, MLBTeams = mlbTeamLookUpItem.DropDownList};

            if (TryUpdateModel(modelVM))
            {
                drdRepo.EditPlayer(modelVM.Player);
                return RedirectToAction("Index", new { id = player.TeamPID });
            }

            return View(modelVM);
        }

        public ActionResult Promote(int id)
        {
            Player player = drdRepo.GetPlayer(id);

            drdRepo.PromotePlayer(id);
            return RedirectToAction("Index", new { id = player.TeamPID });
        }

        public ActionResult GetMajors(int id = 17)
        {
            int rosterSize;

            var majors = drdRepo.ListMajors(out rosterSize, id);

            ViewBag.TeamPID = id;
            ViewBag.TeamRosterSize = rosterSize;

            return PartialView(@"~/Views/Shared/_Majors.cshtml", majors);
        }
    }
}