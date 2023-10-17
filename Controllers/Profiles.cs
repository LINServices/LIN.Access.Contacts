﻿using LIN.Access.Contacts;

namespace LIN.Access.Contacts.Controllers;


public static class Profiles
{


    /// <summary>
    /// Iniciar sesión
    /// </summary>
    /// <param name="cuenta">Cuenta</param>
    /// <param name="password">Contraseña</param>
    /// <param name="app">App de contexto</param>
    public async static Task<ReadOneResponse<Types.Auth.Abstracts.AuthModel<ProfileModel>>> Login(string cuenta, string password)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/login");


        url = Web.AddParameters(url, new(){
            {"user", cuenta },
             {"password", password }
        });


        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.GetAsync(url);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<Types.Auth.Abstracts.AuthModel<ProfileModel>>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }



    /// <summary>
    /// Login
    /// </summary>
    /// <param name="token">Token de acceso</param>
    public async static Task<ReadOneResponse<Types.Auth.Abstracts.AuthModel<ProfileModel>>> Login(string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/login/token");


        url = Web.AddParameters(url, new(){
            {"token", token }
        });


        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.GetAsync(url);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<Types.Auth.Abstracts.AuthModel<ProfileModel>>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }



}
