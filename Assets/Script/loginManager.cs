using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public static LoginManager Instance;
    
    public string principal;
    public bool logeoExitoso = false;
    [SerializeField] Button Boton;

    [SerializeField] private GameObject _loadingCanvas;

    //[SerializeField] public TMP_InputField inputUserName;
    public User usuario;

    private void Awake()
    {
        if (Instance!= null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
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

                //nftManager.PedirNFTS();
                SceneLoadingManager.instance.ChangeScene("MainMenu");
            }
            else
            {
                Boton.interactable = true;
                _loadingCanvas.SetActive(false);
                Debug.Log("Error en getPrincipal2");
            }
        }
        else
        {
            Boton.interactable = true;
            _loadingCanvas.SetActive(false);
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
#if UNITY_EDITOR
        SceneLoadingManager.instance.ChangeScene("MainMenu");
#else
        Boton.interactable = false;
        _loadingCanvas.SetActive(true);
        Debug.Log("Logueandose...");
        ReacFunctions.Login();
        //text = "Loading...";
#endif
    }
}