using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _messagePool;
    [SerializeField] private TextMeshProUGUI _chatBox;
    [SerializeField] private Transform _parent;
    [SerializeField] private ScrollRect _scrollView;

    [SerializeField] private TMP_InputField _inputField;

    private WebSocketChatClient _ws;

    private int _actualIndexPool;

    private void Awake()
    {
        EventManager.Subscribe("ReceiveMessage", ReceiveMessage);

        // foreach (var message in _messagePool)
        // {
        //     message.SetActive(false);
        //     message.transform.parent = null;
        // }
    }

    private void Start()
    {
        _ws=GetComponent<WebSocketChatClient>();

        if (_ws != null)
        {
            _chatBox.text += "<br>" + "Got WebSocket!";
        }
        else
        {
            _chatBox.text += "<br>" + "ERROR! Failed to get WebSocket.";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToServer();
        }
    }

    public void SendMessageToServer()
    {
        if (_inputField.text.Length<= 0) return;
        
        _ws.SendMessageToServer(_inputField.text);
        _chatBox.text += "<br>" + "SENT";
        _inputField.text = "";
    }

    public void ReceiveMessage(params object[] parameters)
    {
        /*if (_actualIndexPool>=_messagePool.Length)
        {
            _actualIndexPool = 0;
        }
        
        _messagePool[_actualIndexPool].transform.SetParent(null);
        _messagePool[_actualIndexPool].transform.SetParent(_parent, false);
        _messagePool[_actualIndexPool].SetActive(true);
        
        var messageText = _messagePool[_actualIndexPool].GetComponent<TextMeshProUGUI>();
        messageText.text = parameters[0].ToString();*/

        _chatBox.text += "<br>" + "RECIEVE";
        _chatBox.text += "<br>" + parameters[0].ToString();
        
        StartCoroutine(MessageCoroutine());
        
        _actualIndexPool++;
    }
    
    private IEnumerator MessageCoroutine()
    {
        yield return null;
        _scrollView.normalizedPosition = new Vector2(1, 1);
    }
}
