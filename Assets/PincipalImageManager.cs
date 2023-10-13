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
    }

    public void SetearImagen()
    {
        // Obtén los componentes Image de imagenPrincipal y miBoton
        this.imagenPrincipal.SetActive(true);
        Image imagenPrincipalImage = imagenPrincipal.GetComponent<Image>();
        Image miBotonImage = miBoton.image;

        // Verifica que los componentes no sean nulos antes de intentar asignar la imagen
        if (imagenPrincipalImage != null && miBotonImage != null)
        {
            imagenPrincipalImage.sprite = miBotonImage.sprite;
            imagenPrincipalImage.color = miBotonImage.color;
            // Puedes copiar otros atributos de la imagen si es necesario
        }
    }
}
