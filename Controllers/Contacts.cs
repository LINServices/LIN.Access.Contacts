using LIN.Access.Services;

namespace LIN.Access.Contacts.Controllers;


public static class Contacts
{


    /// <summary>
    /// Crear un contacto.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(string token, ContactModel modelo)
    {

        // Cliente
        Client client = Service.GetClient($"contacts");

        // Headers.
        client.AddHeader("token", token);

        return await client.Post<CreateResponse>(modelo);

    }



    /// <summary>
    /// Obtiene los contactos asociados a un perfil.
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public async static Task<ReadAllResponse<ContactModel>> ReadAll(string token)
    {



        // Cliente
        Client client = Service.GetClient($"contacts/all");

        // Headers.
        client.AddHeader("token", token);

        return await client.Get<ReadAllResponse<ContactModel>>();

    }



    /// <summary>
    /// Obtener un contacto.
    /// </summary>
    /// <param name="id">Id del contacto.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<ContactModel>> Read(int id, string token)
    {

        // Cliente
        Client client = Service.GetClient($"contacts");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        return await client.Get<ReadOneResponse<ContactModel>>();

    }



    /// <summary>
    /// Eliminar un contacto.
    /// </summary>
    /// <param name="id">Id del contacto.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente
        Client client = Service.GetClient($"contacts");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        return await client.Delete<ResponseBase>();

    }



    /// <summary>
    /// Actualizar un contacto.
    /// </summary>
    /// <param name="contact">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(ContactModel contact, string token)
    {

        // Cliente
        Client client = Service.GetClient($"contacts");

        // Headers.
        client.AddHeader("token", token);

        return await client.Patch<ResponseBase>(contact);

    }



}