using System;
using System.Collections;
using UnityEngine;
using WebSocketSharp;

public class WebSocketChatClient : MonoBehaviour
{
    private WebSocket ws;

    private MessageManager _messageManager;

    private string _message = "";

    private void Start()
    {
        _messageManager = GetComponent<MessageManager>();
        StartCoroutine(CheckNewMessage());
        
        // Connect to the server
        //ws = new WebSocket("ws://localhost:8080/");
        ws = new WebSocket("ws://ec2-3-133-144-236.us-east-2.compute.amazonaws.com:8080");

        ws.OnMessage += (sender, e) =>
        {
            if (e.IsText)
            {
                _message = e.Data;
            }
            else if (e.IsBinary)
            {
                // Decode the byte array to string
                var decodedMessage = System.Text.Encoding.UTF8.GetString(e.RawData);
                _message = decodedMessage;
            }
        };

        ws.Connect();
    }

    private void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
            ws = null;
        }
    }

    // Send a message to the server
    public void SendMessageToServer(string message)
    {
        if (ws.IsAlive)
        {
            ws.Send(message);
        }
    }

    private IEnumerator CheckNewMessage()
    {
        while (true)
        {
            if (_message == "")
            {
                yield return null;
                continue;
            }
            
            EventManager.Trigger("ReceiveMessage", _message);
            _message = "";
        }
    }
}

