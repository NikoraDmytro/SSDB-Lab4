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
        public const string GetAllDivisions = $"{Base}/divisions";
        public const string GetDivisionsCompetitors = $"{Base}/divisions/{{id}}";
    }
}