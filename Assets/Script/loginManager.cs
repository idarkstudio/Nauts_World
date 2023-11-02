using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private static LoginManager Instance;
    
    public string principal;
    public bool logeoExitoso = false;
    [SerializeField] GameObject panel;
    [SerializeField] DontDestroyOnLoad sceneManager;
    [SerializeField] CanvasGroup BackGround;
    [SerializeField] Button Boton;
    [SerializeField] public TMP_InputField inputUserName;
    [SerializeField] Button BotonName;
    [SerializeField] Text labelError;
    public User usuario;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Boton.onClick.AddListener(ProbarLogin);
        //BotonName.onClick.AddListener(EnterName); 
    }

    public void GetPrincipal(string json)
    {
        if (json != null)
        {
            ResultUser result = JsonConvert.DeserializeObject<ResultUser>(json);
            Debug.Log($"{result.Principal}");
            if (result != null)
            {

                //if (result.SetName)
                //{
                //    this.panel.SetActive(true);
                //    this.BackGround.interactable = false;
                //    //pedir nombre  
                //}
                //else
                //{
                //}
                
                //cambio de escena
                this.logeoExitoso = true;
                sceneManager.CargarEscena("MainMenu", "Loading1");
                this.principal = result.Principal;
                Debug.Log($"Principal: {principal}");
                Debug.Log($"Principal2 : {result.Principal}");
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
    //public void EnterName() 
    //{
    //    if (!string.IsNullOrEmpty(this.inputUserName.text)|| !string.IsNullOrEmpty(this.principal))
    //    {
    //        string name = this.inputUserName.text;
    //        this.usuario = new User(name, this.principal);

    //        string JsonUser = JsonConvert.SerializeObject(this.usuario);

    //        ReacFunctions.SetUserName(JsonUser);
    //        Debug.Log(JsonUser);
    //        //aca cambiamos de escena 
    //        this.logeoExitoso = true;
    //        sceneManager.CargarEscena("MainMenu", "Loading1");
    //    }
    //    else 
    //    {
    //        this.labelError.color = Color.red;
    //        this.labelError.text = "Error, name invalid";
    //    }
    //}

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

