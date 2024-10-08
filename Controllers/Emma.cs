﻿using LIN.Types.Cloud.OpenAssistant.Api;

namespace LIN.Access.Contacts.Controllers;


public class Emma
{


    /// <summary>
    /// Obtiene las conversaciones asociadas a un perfil
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public static async Task<ReadOneResponse<AssistantResponse>> ToEmma(string modelo, string token)
    {

        // Cliente
        Client client = Service.GetClient($"Emma");

        // Headers.
        client.AddHeader("tokenAuth", token);

        return await client.Post<ReadOneResponse<AssistantResponse>>(modelo);

    }



}