namespace eCinema.Model.Constants
{
    public static class ProjectionStatus
    {
        public const string All = "Svi";
        
        public const string Initialized = "Napravljena";

        public const string Scheduled = "Zakazana";

        public const string Started = "Počela";

        public const string Finished = "Završila";

        public const string Canceled = "Otkazana";

        public static readonly List<string> ListOfStatuses = new()
        {
            All,Scheduled,Started,Finished,Canceled
        };
    }
}
