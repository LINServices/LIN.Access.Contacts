using Microsoft.Extensions.DependencyInjection;

namespace LIN.Access.Contacts;

public static class Extensions
{

    /// <summary>
    /// Utilizar LIN Authentication.
    /// </summary>
    /// <param name="app">Aplicación.</param>
    /// <param name="url">Ruta.</param>
    public static IServiceCollection AddContactsService(this IServiceCollection service, string? url = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "https://api.linplatform.com/contacts/");
        return service;
    }

}