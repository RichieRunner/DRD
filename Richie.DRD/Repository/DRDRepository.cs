using System;
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
                            IPs = reader["IPs"] as decimal? ?? default(decimal)
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

        public void PromotePlayer(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "DRD_Player_Promote";
                sqlCommand.Parameters.Add("@PlayerPID", SqlDbType.Int).Value = id;

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
                    new SqlParameter { ParameterName = "PlayerPID", SqlDbType = SqlDbType.Int, Value = id }
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
                        RowNum = reader["RowNum"] as string ?? default(string),
                        PlayerPID = (int)reader["PlayerPID"],
                        MLBID = reader["MLBID"] as int? ?? default(int),
                        BREFID = reader["BREFID"] as string ?? default(string),
                        FirstName = reader["FirstName"] as string ?? default(string),
                        LastName = reader["LastName"] as string ?? default(string),
                        FullName = reader["FullName"] as string ?? default(string),
                        MLBTeamID = reader["MLBTeamID"] as int? ?? default(int),
                        MLBTeamAbbreviation = reader["MLBTeamAbbreviation"] as string ?? default(string),
                        PositionEID = reader["PositionEID"] as int? ?? default(int),
                        PositionName = reader["PositionName"] as string ?? default(string),
                        TeamPID = reader["TeamPID"] as int? ?? default(int),
                        TeamName = reader["TeamName"] as string ?? default(string),
                        ABs = reader["ABs"] as int? ?? default(int),
                        IPs = reader["IPs"] as int? ?? default(int),
                        Draft = reader["Draft"] as string ?? default(string),
                        RookieQualifier = reader["RookieQualifier"] as string ?? default(string),
                        HasLostRookieStatus = reader["HasLostRookieStatus"] as bool? ?? default(bool),
                        IsActive = reader["IsActive"] as bool? ?? default(bool),
                        DRDPromotionDate = reader["DRDPromotionDate"] as DateTime? ?? default(DateTime),
                        MLBOverallRanking = reader["MLBOverallRanking"] as Int16? ?? default(Int16),
                        CurrentLevel = reader["CurrentLevel"] as string ?? default(string)
                    };
                    returnPlayers.Add(player);
                }

                return returnPlayers;
            }
        }


        public IEnumerable<Majors> ListMajors(out int rosterSize, int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = @"DRD_Majors_List";

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

                var returnMajors = new List<Majors>();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var majors = new Majors()
                        {
                            TeamPID = (int)reader["TeamPID"],
                            Player = reader["Player"] as string ?? default(string),
                            TeamName = reader["TeamName"] as string ?? default(string)
                        };
                        returnMajors.Add(majors);
                    }
                }
                connection.Close();
                return returnMajors;
            }
        }

        public Team GetTeam(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = @"DRD_Team_Get";

                sqlCommand.Parameters.Add("TeamPID", SqlDbType.Int).Value = id;
                connection.Open();
                sqlCommand.ExecuteNonQuery();

                var returnTeam = new List<Team>();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var team = new Team()
                        {
                            TeamPID = (int)reader["TeamPID"],
                            TeamName = reader["TeamName"] as string ?? default(string)
                        };
                        returnTeam.Add(team);
                    }
                }
                connection.Close();

                if (returnTeam.Count() < 1)
                {
                    return new Team { TeamName = "" };
                }
                return returnTeam[0];

            }
        }

        public DateTime GetLastUpdatedDate(out DateTime UpdatedDate)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = @"DRD_Web_status";

                SqlParameter LastUpdatedDate = new SqlParameter("@LastUpdated", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Output
                };
                LastUpdatedDate.Size = 5;
                sqlCommand.Parameters.Add(LastUpdatedDate);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

                UpdatedDate = DateTime.Parse(LastUpdatedDate.Value.ToString());

                return UpdatedDate;

            }
        }


        public IEnumerable<FarmRanking> ListFarmRanking()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = @"DRD_FarmRanking_List";

                connection.Open();
                sqlCommand.ExecuteNonQuery();

                var returnFarmRanking = new List<FarmRanking>();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var FarmRanking = new FarmRanking()
                        {
                            TeamPID = reader["TeamPID"] as int? ?? default(int),
                            TeamName = reader["TeamName"] as string ?? default(string),
                            RankingScore = reader["RankingScore"] as int? ?? default(int),
                            NumberOfRookiesInTop100 = reader["NumberOfRookiesInTop100"] as int? ?? default(int),
                            RookiesList = reader["RookiesList"] as string ?? default(string),
                            RowNum = reader["RowNum"] as int? ?? default(int)
                        };
                        returnFarmRanking.Add(FarmRanking);
                    }
                }
                connection.Close();
                return returnFarmRanking;
            }
        }

        public List<Team> ListTeams()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = @"DRD_Teams_List";

                connection.Open();
                sqlCommand.ExecuteNonQuery();

                var returnTeams = new List<Team>();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var team = new Team()
                        {
                            TeamPID = reader["TeamPID"] as int? ?? default(int),
                            TeamName = reader["TeamName"] as string ?? default(string),
                            RosterSize = reader["RosterSize"] as int? ?? default(int)
                        };
                        returnTeams.Add(team);
                    }
                }
                connection.Close();
                return returnTeams;
            }
        }


    }
}