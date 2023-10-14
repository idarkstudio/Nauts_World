using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loginManager : MonoBehaviour
{
    private static loginManager Instance;
    public string principal;
    [SerializeField] Button Boton;
    [SerializeField] nftManager nftManager;
    [SerializeField] TextMeshPro inputUserName;
    public User usuario;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Boton.onClick.AddListener(ProbarLogin);
    }

    public void GetPrincipal(string json)
    {
        ResultUser result = JsonConvert.DeserializeObject<ResultUser>(json);
        if (result != null) 
        {
            if(!result.setearName) 
            {
                //pedir nombre
                SetNameUser();
            }

            result.principal = principal;
            Debug.Log($"Principal: { principal}");
            nftManager.PedirNFTS();
        }
        else
        {
            Debug.Log("Error en getPrincipal");
        }
    }

    public void SetNameUser() 
    {
        if (!string.IsNullOrEmpty(this.inputUserName.text)) 
        {
            string name = this.inputUserName.text;
            this.usuario = new User(name, this.principal);

            string JsonUser = JsonConvert.SerializeObject(this.usuario);

            ReacFunctions.SetUserName(JsonUser);
        }   
    }

    void ProbarLogin()
    {
        Debug.Log("Logueandose...");
        ReacFunctions.Login();
        //text = "Loading...";

    }
}
