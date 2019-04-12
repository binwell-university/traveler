namespace Traveler
{
    public enum AppPages
    {
        Main,
        MainTabbed,
        Display,
        Calendar,
        EventDescription,
        EventName,
        EventsList,
        TravelName,
        Settings
    }

    public enum NavigationMode
    {
        Normal,
        Modal,
        Root,
        Custom
    }

    public enum PageState
    {
        Clean,
        Loading,
        Normal,
        NoData,
        Error,
        NoInternet
    }
}

