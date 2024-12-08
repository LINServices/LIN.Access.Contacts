namespace LIN.Access.Contacts.Controllers;

public static class Profiles
{

    /// <summary>
    /// Iniciar sesión.
    /// </summary>
    /// <param name="cuenta">Cuenta.</param>
    /// <param name="password">Contraseña.</param>
    public static async Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>> Login(string cuenta, string password)
    {

        // Cliente
        Client client = Service.GetClient($"profile/login");

        // Segundos.
        client.TimeOut = 15;

        // Headers.
        client.AddParameter("user", cuenta);
        client.AddParameter("password", password);

        return await client.Get<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>>();

    }


    /// <summary>
    /// Login con token.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>> Login(string token)
    {

        // Cliente
        Client client = Service.GetClient($"profile/login/token");

        // Segundos.
        client.TimeOut = 15;

        // Headers.
        client.AddHeader("token", token);

        return await client.Get<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>>();

    }


    /// <summary>
    /// Obtener los dispositivos.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadAllResponse<DeviceModel>> ReadDevices(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("devices");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<DeviceModel>>();

        // Retornar.
        return Content;

    }

}