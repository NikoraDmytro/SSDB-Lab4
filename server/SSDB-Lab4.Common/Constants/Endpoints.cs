namespace SSDB_Lab4.Common.Constants;

public class Endpoints
{
    public static class Sportsmen
    {
        public const string Base = "/api/sportsmen";
        public const string GetAll = Base;
        public const string GetById = $"{Base}/{{id}}";
        public const string Create = Base;
        public const string Update = $"{Base}/{{id}}";
        public const string Delete = $"{Base}/{{id}}";
    }
    
    public static class Competitions
    {
        public const string Base = "/api/competitions";
        public const string GetAll = Base;
        public const string GetById = $"{Base}/{{id}}";
        public const string Create = Base;
        public const string Update = $"{Base}/{{id}}";
        public const string Delete = $"{Base}/{{id}}";
        public const string GetAvailableSportsmen =
            $"{Base}/{{id}}/sportsmen";
        public const string GetDivisions = $"{Base}/{{id}}/divisions";
        public const string GetDivisionCompetitors = 
            $"{Base}/{{id}}/divisions/{{divisionId}}";
        public const string GetLargestCompetition =
            $"{Base}/largest";
        public const string GetLargestDivision =
            $"{Base}/{{id}}/divisions/largest";
        public const string GetCompetitionCopies =
            $"{Base}/copies";
    }
    
    public static class Divisions
    {
        public const string Base = "/api/divisions";
        public const string GetAll = Base;
        public const string GetById = $"{Base}/{{id}}";
        public const string Create = Base;
        public const string Update = $"{Base}/{{id}}";
        public const string Delete = $"{Base}/{{id}}";
    }
    
    public static class Competitors
    {
        public const string Base = "/api/competitions/{competitionId}/competitors";
        public const string GetAll = Base;
        public const string GetById = $"{Base}/{{id}}";
        public const string Create = Base;
        public const string SetWeight = $"{Base}/{{id}}/weight";
        public const string SetLapNum = $"{Base}/{{id}}/lap"; 
        public const string Delete = $"{Base}/{{id}}";
        public const string GetLogs = $"{Base}/logs";
        public const string GetFailedInsertLogs =
            $"{Base}/failed";
    }
}