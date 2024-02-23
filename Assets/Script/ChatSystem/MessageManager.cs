using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private GameObject _messagePrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private ScrollRect _scrollView;

    [SerializeField] private TMP_InputField _inputField;

    private WebSocketChatClient _ws;

    private void Awake()
    {
        EventManager.Subscribe("ReceiveMessage", ReceiveMessage);
    }

    private void Start()
    {
        _ws=GetComponent<WebSocketChatClient>();
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
        _inputField.text = "";
    }

    private void ReceiveMessage(params object[] parameters)
    {
        var messageText = Instantiate(_messagePrefab, _parent).GetComponent<TextMeshProUGUI>();
        messageText.text = parameters[0].ToString();
        StartCoroutine(MessageCoroutine());
    }
    
    private IEnumerator MessageCoroutine()
    {
        yield return null;
        _scrollView.normalizedPosition = new Vector2(0, 0);
    }
}
