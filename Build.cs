namespace LIN.Access.Contacts;


public class Build
{

    /// <summary>
    /// Iniciar el servicio.
    /// </summary>
    public static void Init()
    {
        Service._Service = new();
        Service._Service.SetDefault("https://api.contacts.linplatform.com/");
    }


}