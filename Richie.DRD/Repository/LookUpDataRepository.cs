using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

using Richie.DRD.Models;


namespace Richie.DRD.Repository
{
    public class LookUpDataRepository : ILookUpDataRepository
    {
        private string connectionString;

        public LookUpDataRepository()
        {
            const string connectionStringName = "RichieConnection";
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public LookUpItem getTeams()
        {
            LookUpItem lookUpItem = new LookUpItem();

            using (var connection = new SqlConnection(this.connectionString))
            {
                var commandText = "SELECT TeamPID, TeamName FROM DRD_TS_Team";

                var command = new SqlCommand(commandText, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    lookUpItem.DropDownList = new List<SelectListItem>();

                    while (reader.Read())
                    {
                        lookUpItem.DropDownList.Add(new SelectListItem { Text = (string)reader["TeamName"], Value = reader.GetInt16(0).ToString() });
                    }
                }

            }

            return lookUpItem;

        }

        public LookUpItem getPositions()
        {
            LookUpItem lookUpItem = new LookUpItem();

            using (var connection = new SqlConnection(this.connectionString))
            {
                var commandText = "SELECT PositionEID, PositionName FROM DRD_TE_Position";

                var command = new SqlCommand(commandText, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    lookUpItem.DropDownList = new List<SelectListItem>();

                    while (reader.Read())
                    {
                        lookUpItem.DropDownList.Add(new SelectListItem { Text = (string)reader["PositionName"], Value = reader.GetInt32(0).ToString() });
                    }
                }

            }

            return lookUpItem;

        }

        public LookUpItem getMLBTeams()
        {
            LookUpItem lookUpItem = new LookUpItem();
            lookUpItem.DropDownList = new List<SelectListItem>();

            Array MLBTeams = Enum.GetValues(typeof(MLBTeam));
            foreach (int MLBTeamID in MLBTeams)
            {
                lookUpItem.DropDownList.Add(new SelectListItem { Text = Enum.GetName(typeof(MLBTeam), MLBTeamID), Value = MLBTeamID.ToString() });
            }

            return lookUpItem;

            //using (var connection = new SqlConnection(this.connectionString))
            //{
            //    var commandText = "SELECT MLBTeamID, MLBTeamAbbreviation FROM DRD_TE_MLBTeam";

            //    var command = new SqlCommand(commandText, connection);
            //    connection.Open();

            //    using (var reader = command.ExecuteReader())
            //    {
            //        lookUpItem.DropDownList = new List<SelectListItem>();

            //        while (reader.Read())
            //        {
            //            lookUpItem.DropDownList.Add(new SelectListItem { Text = (string)reader["MLBTeamAbbreviation"], Value = reader.GetInt32(0).ToString() });
            //        }
            //    }

            //}

            return lookUpItem;

        }


    }
}