using LIN.Types.Emma.Models;

namespace LIN.Access.Contacts.Controllers;


public class Emma
{


    /// <summary>
    /// Obtiene las conversaciones asociadas a un perfil
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public async static Task<ReadOneResponse<ResponseIAModel>> ToEmma(string modelo, string token)
    {

        // Cliente
        Client client = Service.GetClient($"Emma");

        // Headers.
        client.AddHeader("tokenAuth", token);

        return await client.Post<ReadOneResponse<ResponseIAModel>>(modelo);

    }



}