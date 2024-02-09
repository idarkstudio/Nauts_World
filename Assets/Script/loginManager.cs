using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    
    public string principal;
    public bool logeoExitoso = false;
    [SerializeField] Button Boton;
    //[SerializeField] public TMP_InputField inputUserName;
    public User usuario;

    void Start()
    {
        Boton.onClick.AddListener(ProbarLogin);
    }

    public void GetPrincipal(string json)
    {
        if (json != null)
        {
            ResultUser result = JsonConvert.DeserializeObject<ResultUser>(json);
            Debug.Log($"el principal que recibo es estse:  {result.Principal}");
            if (result != null)
            {
                this.logeoExitoso = true;
                this.principal = result.Principal;
                nftManager.PedirNFTS();
            }
            else 
            {
                Debug.Log("Error en getPrincipal2");
            }

        }
        else
        {
            Debug.Log("Error en getPrincipal");
        }

    }


    public void CreateAcount()
    {
        Debug.Log("Creando cuenta...");
        ReacFunctions.CreateAcount();
    }
    void ProbarLogin()
    {
        Debug.Log("Logueandose...");
        ReacFunctions.Login();
        //text = "Loading...";
    }
}

