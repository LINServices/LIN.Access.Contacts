﻿using Microsoft.AspNetCore.SignalR.Client;

namespace LIN.Access.Contacts.Hubs;

public class ContactsAccessHub : IDisposable
{

    /// <summary>
    /// Conexión del HUB
    /// </summary>
    private protected HubConnection? HubConnection { get; set; }


    /// <summary>
    /// Evento al recibir un comando.
    /// </summary>
    public event EventHandler<CommandModel>? On;


    /// <summary>
    /// Token de acceso.
    /// </summary>
    public string Token { get; set; }


    /// <summary>
    /// Modelo del dispositivo.
    /// </summary>
    public DeviceModel Device { get; set; }


    /// <summary>
    /// Nuevo Hub de ViewON.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="device">Modelo del dispositivo.</param>
    public ContactsAccessHub(string token, DeviceModel device)
    {
        Token = token;
        Device = device;
        Suscribe();
    }


    /// <summary>
    /// Obtener el estado actual.
    /// </summary>
    public string GetStatus()
    {
        return HubConnection?.State.ToString() ?? "";
    }


    /// <summary>
    /// Enviar el evento.
    /// </summary>
    /// <param name="cm">Comando.</param>
    private protected void SendEvent(CommandModel cm) => On?.Invoke(null, cm);


    /// <summary>
    /// Iniciar el Hub.
    /// </summary>
    private async void Suscribe()
    {
        try
        {
            // Crea la conexión al HUB
            HubConnection = new HubConnectionBuilder()
                 .WithUrl(Service._Service.PathURL("Realtime/contacts"))
                 .WithAutomaticReconnect()
                 .Build();

            // Evento cuando algo cambie
            HubConnection.On<CommandModel>("#command", SendEvent);

            // Inicia la conexión.
            await HubConnection.StartAsync();

            // Suscribe al grupo
            await HubConnection.InvokeAsync("Join", Token, Device);
        }
        catch (Exception)
        {
        }
    }


    /// <summary>
    /// Enviar un comando.
    /// </summary>
    /// <param name="command">Modelo del comando.</param>
    public async Task SendCommand(CommandModel command)
    {
        try
        {
            await HubConnection!.InvokeAsync("SendCommand", Token, command);
        }
        catch (Exception)
        {
        }
    }


    /// <summary>
    /// Enviar comando a un dispositivo especifico.
    /// </summary>
    /// <param name="device">Device ID.</param>
    /// <param name="command">Comando.</param>
    public async void SendToDevice(string device, CommandModel command)
    {
        try
        {
            await HubConnection!.InvokeAsync("SendToDevice", device, command);
        }
        catch (Exception)
        {
        }
    }


    /// <summary>
    /// Evento Dispose.
    /// </summary>
    public void Dispose()
    {
        _ = HubConnection?.DisposeAsync();
    }

}