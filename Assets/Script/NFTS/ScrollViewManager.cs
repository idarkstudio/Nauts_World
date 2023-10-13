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

    
    


    public List<string> imageUrls; // Tu lista de URL de imágenes.

    [SerializeField ]
    public ImageLoader loaderImage;


    public void Start()
    {
        AsignarImagenes();
        
    }

    public void getCollection(List<NftDelails> collection)
    {
        
            if (collection!= null)
        {
            foreach (var nft in collection)
            {
                imageUrls.Add(nft.image);
            }
        }else
            Debug.Log("sos un desgraciado, te llego un array nulo gil");
    }

    public void pruebaFunciones()
    {
        for (int i = 0; i <= 10; i++)
        {
            imageUrls.Add("https://media.istockphoto.com/id/1433347468/es/foto/el-inspector-y-el-capataz-est%C3%A1n-revisando-las-obras-de-la-casa.jpg?s=1024x1024&w=is&k=20&c=1MYIdo7olYcSU9ZkjbNwelPQy5vISDYqoF6bFrFGi5I=");
        }
    }   
    

    //public async void AsignarImagenes(List<NftDelails> collection)
    //{
    //    getCollection(collection);
    //    foreach (string imageUrl in imageUrls)
    //    {
    //        Debug.Log("estoy asignando las imagenes a mi lista imageUrl");
    //        await LoadAndCreateRawImage(imageUrl);
    //    }
    //}    
    public async void AsignarImagenes()
    {
        pruebaFunciones();
        foreach (string imageUrl in this.imageUrls)
        {
            Debug.Log("estoy asignando las imagenes a mi lista imageUrl");
            await LoadAndCreateRawImage(imageUrl);
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
