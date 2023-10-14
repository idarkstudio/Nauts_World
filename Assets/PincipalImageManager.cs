
using System;
using UnityEngine;
using UnityEngine.UI;

public class PincipalImageManager : MonoBehaviour
{
    GameObject imagenPrincipal;

    [SerializeField]
    private Button miBoton;

    public void Awake()
    {
        imagenPrincipal = GameObject.FindGameObjectWithTag("ImagenPrincipal");
        if (imagenPrincipal == null)
            Debug.LogError(" no encuentro el ttag");
            
    }

    public void SetearImagen()
    {
        imagenPrincipal = GameObject.FindGameObjectWithTag("ImagenPrincipal");

        // Obtén los componentes Image de imagenPrincipal y miBoton
        imagenPrincipal.SetActive(true);// no funciona. asique lo que hago es lo defino con color transparente para que este en la escena cuando lo busco.

        Image imagenPrincipalImage = imagenPrincipal.GetComponent<Image>();
        Image miBotonImage = miBoton.image;

        // Verifica que los componentes no sean nulos antes de intentar asignar la imagen
        if (imagenPrincipalImage != null && miBotonImage != null)
        {
            imagenPrincipalImage.sprite = miBotonImage.sprite;
            imagenPrincipalImage.color = miBotonImage.color;
            imagenPrincipalImage.enabled = true;
            // Puedes copiar otros atributos de la imagen si es necesario
        }
    }
}


