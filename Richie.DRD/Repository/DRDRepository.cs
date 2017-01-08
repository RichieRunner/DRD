﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using MVCGrid.Models;

using Richie.DRD.Models;
using System.Data;

namespace Richie.DRD.Repository
{
    public class DRDRepository : IDRDRepository
    {
        private string connectionString;

        public DRDRepository()
        {
            const string connectiongStringName = "RichieConnection";
            this.connectionString = ConfigurationManager.ConnectionStrings[connectiongStringName].ConnectionString;
        }

        public IEnumerable<Player> GetData(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {

            using (var connection = new SqlConnection(this.connectionString))
            {
                var commandText = @"exec DRD_Player_List";

                var command = new SqlCommand(commandText, connection);

                connection.Open();
                command.ExecuteNonQuery();
                //var listModels = GetPlayers(command);



                var listModels = new List<Player>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var player = new Player()
                        {
                            PlayerPID = (int)reader["PlayerPID"],
                            FirstName = reader["FirstName"] as string ?? default(string),
                            LastName = reader["LastName"] as string ?? default(string),
                            FullName = reader["FullName"] as string ?? default(string),
                            PositionEID = reader["PositionEID"] as int? ?? default(int),
                            PositionName = reader["PositionName"] as string ?? default(string),
                            TeamPID = reader["TeamPID"] as int? ?? default(int),
                            ABs = reader["ABs"] as int? ?? default(int),
                            IPs = reader["IPs"] as int? ?? default(int)
                        };
                        listModels.Add(player);
                    }

                    //return returnPlayers;
                }

                //IDRDRepository repo = new DRDRepository();
                //List<Player> listModels = repo.ListPlayers().ToList();
                var query = listModels.AsQueryable();

                if (!String.IsNullOrWhiteSpace(globalSearch))
                {
                    query = query.Where(p => p.FirstName.ToUpper().Contains(globalSearch.ToUpper()));
                }

                totalRecords = query.Count();

                if (!String.IsNullOrWhiteSpace(orderBy))
                {
                    switch (orderBy.ToLower())
                    {
                        case "firstname":
                            if (!desc)
                                query = query.OrderBy(p => p.FirstName);
                            else
                                query = query.OrderByDescending(p => p.FirstName);
                            break;
                        case "lastname":
                            if (!desc)
                                query = query.OrderBy(p => p.LastName);
                            else
                                query = query.OrderByDescending(p => p.LastName);
                            break;
                    }
                }

                if (limitOffset.HasValue)
                {
                    query = query.Skip(limitOffset.Value).Take(limitRowCount.Value);
                }

                return query.ToList();
            }
        }

        public IEnumerable<Player> GetData (out int rosterSize, out int totalRecords, int teamPID, string globalSearch, string filterFirstName, string filterLastName, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {

            //using (var connection = new SqlConnection(this.connectionString))
            //{
            //    var commandText = @"exec DRD_Player_List";

            //    var command = new SqlCommand(commandText, connection);

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    var listModels = GetPlayers(command);


            IDRDRepository repo = new DRDRepository();
            List<Player> listModels = repo.ListPlayers(out rosterSize, teamPID).ToList();
            var result = new QueryResult<Player>();
            var query = listModels.AsQueryable();

            //if (!String.IsNullOrWhiteSpace(globalSearch))
            //{
            //    query = query.Where(p => p.FirstName.Contains(globalSearch));
            //}
            //if (!String.IsNullOrWhiteSpace(filterLastName))
            //{
            //    query = query.Where(p => p.LastName.Contains(globalSearch));
            //}

            totalRecords = 100; //query.Count();

            if (!String.IsNullOrWhiteSpace(orderBy))
            {
                switch (orderBy.ToLower())
	            {
                    case "firstname":
                        if (!desc)
                            query = query.OrderBy(p => p.FirstName);
                        else
                            query = query.OrderByDescending(p => p.FirstName);
                        break;
                    case "lastname":
                        if (!desc)
                            query = query.OrderBy(p => p.LastName);
                        else
                            query = query.OrderByDescending(p => p.LastName);
                        break;
	            }
            }

            if (limitOffset.HasValue)
            {
                query = query.Skip(limitOffset.Value).Take(limitRowCount.Value);
            }

            return query.ToList();

            //}


        }

        public IEnumerable<Player> ListPlayers(out int rosterSize, int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                /*
                var commandText = @"exec DRD_Player_List ";
                commandText += @"@TeamPID = " + id;

                var command = new SqlCommand(commandText, connection);

                command.Parameters.Add(
                    new SqlParameter { ParameterName = "TeamPID", DbType = DbType.Int32, Value = id }
                    );
                command.Parameters.Add(
                    new SqlParameter { ParameterName = "RosterSize", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output }
                    );
                */

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = @"DRD_Player_List";

                sqlCommand.Parameters.Add("TeamPID", SqlDbType.Int).Value = id;

                SqlParameter rosterSizeOutput = new SqlParameter("@RosterSize", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                rosterSizeOutput.Size = 5000;
                sqlCommand.Parameters.Add(rosterSizeOutput);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                rosterSize = int.Parse(rosterSizeOutput.Value.ToString());
                
                return GetPlayers(sqlCommand);
            }
        }

        public void EditPlayer(Player player)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                //var commandText = @"exec DRD_Player_Update ";
                //commandText += @"@PlayerPID = " + player.PlayerPID + ", ";
                //commandText += @"@PositionEID = " + player.PositionEID + ", ";
                //commandText += @"@MLBTeamID = " + player.MLBTeamID + ", ";
                //commandText += @"@BREFID = " + player.BREFID;

                //var command = new SqlCommand(commandText, connection);

                //command.Parameters.Add(
                //    new SqlParameter { ParameterName = "PlayerPID", DbType = DbType.Int32, Value = player.PlayerPID });
                //command.Parameters.Add(
                //    new SqlParameter { ParameterName = "PositionEID", DbType = DbType.Int32, Value = player.PositionEID });
                //command.Parameters.Add(
                //    new SqlParameter { ParameterName = "MLBTeamID", DbType = DbType.Int32, Value = player.MLBTeamID });
                //command.Parameters.Add(
                //    new SqlParameter { ParameterName = "BREFID", SqlDbType = SqlDbType.VarChar, Value = player.BREFID});


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "DRD_Player_Update";
                sqlCommand.Parameters.Add("@PlayerPID", SqlDbType.VarChar).Value = player.PlayerPID;
                sqlCommand.Parameters.Add("@PositionEID", SqlDbType.VarChar).Value = player.PositionEID;
                sqlCommand.Parameters.Add("@MLBTeamID", SqlDbType.Int).Value = player.MLBTeamID;
                sqlCommand.Parameters.Add("@MLBID", SqlDbType.VarChar).Value = player.MLBID;

                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
        }

        public Player GetPlayer(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var commandText = @"exec DRD_Player_Get ";
                commandText += @"@PlayerPID = " + id;

                var command = new SqlCommand(commandText, connection);

                command.Parameters.Add(
                    new SqlParameter { ParameterName = "PlayerPID", DbType = DbType.Int32, Value = id }
                    );

                connection.Open();
                var players = GetPlayers(command);

                if (players.Count() < 1)
                {
                    return null;
                }
                return players[0];
            }
        }

        private List<Player> GetPlayers(SqlCommand command)
        {
            var returnPlayers = new List<Player>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var player = new Player()
                    {
                        PlayerPID = (int)reader["PlayerPID"],
                        MLBID = reader["MLBID"] as int? ?? default(int),
                        BREFID = reader["BREFID"] as string ?? default(string),
                        FirstName = reader["FirstName"] as string ?? default(string),
                        LastName = reader["LastName"] as string ?? default(string),
                        FullName = reader["FullName"] as string ?? default(string),
                        YearDrafted = reader["YearDrafted"] as int? ?? default(int),
                        MLBTeamID = reader["MLBTeamID"] as int? ?? default(int),
                        MLBTeamAbbreviation = reader["MLBTeamAbbreviation"] as string ?? default(string),
                        PositionEID = reader["PositionEID"] as int? ?? default(int),
                        PositionName = reader["PositionName"] as string ?? default(string),
                        TeamPID = reader["TeamPID"] as int? ?? default(int),
                        TeamName = reader["TeamName"] as string ?? default(string),
                        ABs = reader["ABs"] as int? ?? default(int),
                        IPs = reader["IPs"] as int? ?? default(int)
                    };
                    returnPlayers.Add(player);
                }

                return returnPlayers;
            }
        }

    }
}