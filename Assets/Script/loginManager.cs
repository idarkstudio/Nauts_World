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
        BotonName.onClick.AddListener(EnterName); 
    }

    public void GetPrincipal(string json)
    {
        if (json != null)
        {
            ResultUser result = JsonConvert.DeserializeObject<ResultUser>(json);
            if (result != null)
            {
                if (result.setName)
                {
                    if (result.setName)
                    {
                        this.panel.SetActive(true);
                        this.BackGround.interactable = false;
                        //pedir nombre  
                    }
                    else
                    {
                        //cambio de escena
                        this.logeoExitoso = true;
                        sceneManager.LoadScene("MainMenu", "Loading1");
                    }

                }
                else
                {
                    Debug.Log("Usuario longaniza");
                }

                result.principal = principal;
                Debug.Log($"Principal: {principal}");
                Debug.Log($"Principal2 : {result.principal}");
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
    public void EnterName() 
    {
        if (!string.IsNullOrEmpty(this.inputUserName.text))
        {
            string name = this.inputUserName.text;
            this.usuario = new User(name, this.principal);

            string JsonUser = JsonConvert.SerializeObject(this.usuario);

            ReacFunctions.SetUserName(JsonUser);
            //aca cambiamos de escena 
            this.logeoExitoso = true;
            sceneManager.LoadScene("MainMenu", "Loading1");
        }
        else 
        {
            this.labelError.color = Color.red;
            this.labelError.text = "Error, name invalid";
        }
    }

    void ProbarLogin()
    {
        Debug.Log("Logueandose...");
        ReacFunctions.Login();
        //text = "Loading...";
    }
}
