[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Richie.DRD.MVCGridConfig), "RegisterGrids")]

namespace Richie.DRD
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;

    using Richie.DRD.Models;
    using Richie.DRD.Repository;

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {
            /*
            var fullNameColumn = new GridColumn<Player>()
            {
                ColumnName = "FullName",
                HeaderText = "Full Name",
                HtmlEncode = false,
                ValueExpression = (p, c) => p.FullName.ToString()
            };

            MVCGridDefinitionTable.Add("PlayersGrid", new MVCGridBuilder<Player>());

            GridDefinition<Player> def = MVCGridDefinitionTable.GetDefinition<Player>("PlayersGrid");

            def.RetrieveData = (options) =>
            {
                DRDRepository repo = new DRDRepository();
                List<Player> listModels = repo.ListPlayers().ToList();
                var result = new QueryResult<Player>();
                var query = listModels.AsQueryable();

                result.TotalRecords = query.Count();
                result.Items = query.ToList();
                return result;
            };

            def.AddColumn(fullNameColumn);
            */

            //Func<GridContext, QueryResult<Player>> loadDate = (context) =>
            //{
            //    var result = new QueryResult<Player>();
            //    DRDRepository repo = new DRDRepository();
            //    result.Items = repo.ListPlayers(context.GridName);
            //    return result;
            //};

            //MVCGridDefinitionTable.Add("PlayersGrid", new MVCGridBuilder<Player>()
            //    .AddColumn(fullNameColumn).WithRet

            //);


            
            MVCGridDefinitionTable.Add("PlayersGrid", new MVCGridBuilder<Player>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous).WithPaging(false)
                .WithSorting(sorting: true, defaultSortColumn: "PlayerPID", defaultSortDirection: SortDirection.Dsc)
                .WithPaging(true, 100, true, 100)
                .WithAdditionalQueryOptionNames("search")
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add("PlayerPID").WithValueExpression(p => p.PlayerPID.ToString());
                    cols.Add().WithValueExpression(p => p.FullName)
                        .WithColumnName("Full Name")
                        .WithHeaderText("Full Name")
                        .WithAllowChangeVisibility(true)
                        //.WithFiltering(true)
                        .WithSorting(true);
                    cols.Add().WithValueExpression(p => p.FirstName)
                        .WithColumnName("firstname")
                        .WithHeaderText("First Name")
                        .WithAllowChangeVisibility(true)
                        //.WithFiltering(true)
                        .WithSorting(true);
                    //cols.Add().WithValueExpression(p => p.LastName);
                    //cols.Add().WithValueExpression(p => p.PositionEID.ToString()).WithColumnName("Position");
                    //cols.Add().WithValueExpression(p => p.ABs.ToString()).WithColumnName("ABs");
                    //cols.Add().WithValueExpression(p => p.IPs.ToString()).WithColumnName("IPs"); 
                    
                    
                    // use the Value Expression to return the cell text for this column
                    //cols.Add().WithColumnName("UrlExample")
                    //    .WithHeaderText("Edit")
                    //    .WithValueExpression((i, c) => c.UrlHelper.Action("detail", "demo", new { id = i.Id }));
                })
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;

                    int totalRecords;

                    string globalSearch = options.GetAdditionalQueryOptionString("search");

                    string globalSearch2 = options.GetFilterString("firstname");

                    string sortColumn = options.GetSortColumnData<string>();

                    IDRDRepository repo = new DRDRepository();
                    //List<Player> listModels = repo.ListPlayers().ToList();
                    //var result = new QueryResult<Player>();
                    //var query = listModels.AsQueryable();

                    //var items = repo.GetData(out totalRecords,
                    //                            globalSearch,
                    //                            options.GetLimitOffset(),
                    //                            options.GetLimitRowcount(),
                    //                            options.GetSortColumnData<string>(),
                    //                            //"firstname",
                    //                            options.SortDirection == SortDirection.Dsc);

                    var items = repo.GetData(out totalRecords, globalSearch, null, null, "firstname", options.SortDirection == SortDirection.Dsc);


                    return new QueryResult<Player>()
                    {
                        Items = items,
                        TotalRecords = totalRecords

                    };

                })
            );
            
        }
    }
}