namespace eCinema.Model.Constants
{
    public static class NotificationTypes
    {
        public const string All = "Svi";
        
        public const string Holiday = "Praznik";

        public const string DayOff = "Neradni dan";

        public const string Trending = "Trending";

        public const string SpecialActions = "Posebne ponude";

        public static readonly List<string> ListOfNotificationTypes = new()
        {
            All,DayOff,Trending,SpecialActions,Holiday
        };

    }
}
