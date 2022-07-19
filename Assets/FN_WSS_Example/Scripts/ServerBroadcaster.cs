using FishNet.Connection;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerBroadcaster : NetworkBehaviour
{

    public override void OnStartServer()
    {
        base.OnStartServer();

        ServerManager.RegisterBroadcast<ChatMsg>(OnChatMsg);
    }

    public override void OnStopServer()
    {
        base.OnStopServer();

        ServerManager.UnregisterBroadcast<ChatMsg>(OnChatMsg);
    }

    private void OnChatMsg(NetworkConnection conn, ChatMsg msg)
    {

        Debug.Log($"Client {conn.ClientId} sent msg: {msg.Text}");

        msg.Text = $"{conn.ClientId}: {msg.Text}";

        ServerManager.Broadcast(msg);

    }

}
