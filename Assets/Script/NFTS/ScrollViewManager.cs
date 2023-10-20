using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ScrollViewManager : MonoBehaviour
{
    [SerializeField]
    GameObject buttonImagePrefab; // Asigna el prefab de RawImage aquí.
    public Transform contentTransform; // Asigna el Transform del Content del ScrollView aquí.

    [SerializeField ]
    public ImageLoader loaderImage;

    public async void AsignarImagenes(List<NftDelails> listImages)
    {
        foreach (NftDelails imageUrl in listImages)
        {
            if (imageUrl.isOwner)
            {
                //los muestro como vienen
            }
            else 
            {
               //los hago grises
            }
            await LoadAndCreateRawImage(imageUrl.image);
            //Debug.Log("estoy asignando las imagenes a mi lista imageUrl");
        }
    }

    private Task LoadAndCreateRawImage(string imageUrl)
    {
        GameObject imageGO = Instantiate(buttonImagePrefab, contentTransform);
        Button image = imageGO.GetComponent<Button>();
        //imageGO.SetActive(false);

        loaderImage.AssignImage(imageUrl, image, (texture) =>
        {

        });
        return Task.CompletedTask;
    }
}
