namespace LIN.Access.Contacts.Controllers;


public static class Profiles
{


    /// <summary>
    /// Iniciar sesión.
    /// </summary>
    /// <param name="cuenta">Cuenta.</param>
    /// <param name="password">Contraseña.</param>
    public async static Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>> Login(string cuenta, string password)
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
    public async static Task<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>> Login(string token)
    {

        // Cliente
        Client client = Service.GetClient($"profile/login/token");

        // Segundos.
        client.TimeOut = 15;

        // Headers.
        client.AddParameter("token", token);

        return await client.Get<ReadOneResponse<Types.Cloud.Identity.Abstracts.AuthModel<ProfileModel>>>();

    }



}