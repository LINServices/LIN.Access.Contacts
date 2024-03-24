namespace LIN.Access.Contacts;


public class Build
{

    public static void Init()
    {
        Service._Service = new();
        Service._Service.SetDefault("http://api.contacts.linapps.co/");
    }


}
