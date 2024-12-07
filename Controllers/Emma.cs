namespace LIN.Access.Contacts.Controllers;

public class Emma
{

    /// <summary>
    /// Obtiene las conversaciones asociadas a un perfil
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<Types.Cloud.OpenAssistant.Models.EmmaSchemaResponse>> ToEmma(string modelo, string token)
    {

        // Cliente
        Client client = Service.GetClient($"Emma");

        // Headers.
        client.AddHeader("tokenAuth", token);

        return await client.Post<ReadOneResponse<LIN.Types.Cloud.OpenAssistant.Models.EmmaSchemaResponse>>(modelo);

    }

}