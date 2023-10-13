using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginManager : MonoBehaviour
{
    private static loginManager Instance;
    public string principal;
    public Button Boton;
    nftManager nftManager;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Boton.onClick.AddListener(ProbarLogin);
    }

    public void GetPrincipal(string principal)
    {
        if (principal != null)
        {
            this.principal = principal;
            Debug.Log($"Principal: { principal}");
            nftManager.PedirNFTS();
        }
        else
        {
            Debug.Log("Error en getPrincipal");
        }
    }

    void ProbarLogin()
    {
        Debug.Log("Logueandose...");
        ReacFunctions.Login();
        //text = "Loading...";

    }
}
