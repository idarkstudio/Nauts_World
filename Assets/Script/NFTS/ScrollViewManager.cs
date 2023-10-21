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
    [SerializeField]
    GameObject buttonBlocked; 
    public Transform contentTransform; // Asigna el Transform del Content del ScrollView aquí.

    [SerializeField ]
    public ImageLoader loaderImage;

    public async void AsignarImagenes(List<NftDelails> listImages)
    {
        foreach (NftDelails imageUrl in listImages)
        {
            if (imageUrl.isOwner)
            {
                await LoadAndCreateRawImage(imageUrl.image,buttonImagePrefab);
                //los muestro como vienen
            }
            else 
            {

                await LoadAndCreateRawImage(imageUrl.image,buttonBlocked);
               //los hago grises
            }
            //Debug.Log("estoy asignando las imagenes a mi lista imageUrl");
        }
    }
    //public List<NftDelails> cargarNft()
    //{
    //    List<NftDelails> listaxd = new List<NftDelails> (); 
    //    NftDelails nft1 = new NftDelails();
    //    nft1.collection = "collection";
    //    nft1.image = "https://34xdl-mqaaa-aaaan-qcweq-cai.raw.ic0.app/file/3_thumb.jpeg";
    //    nft1.name = "nombre";
    //    nft1.description = "description";
    //    nft1.isOwner = true;
    //    NftDelails nft2 = new NftDelails();
    //    nft1.collection = "collection";
    //    nft1.image = "https://34xdl-mqaaa-aaaan-qcweq-cai.raw.ic0.app/file/1_thumb.jpeg";
    //    nft1.name = "nombre";
    //    nft1.description = "description";
    //    nft1.isOwner = true;
    //    listaxd.Add(nft1);
    //    listaxd.Add(nft2);
    //    return listaxd;
    //}
    private void Start()
    {
        //List<NftDelails> lista = cargarNft();
        //AsignarImagenes(lista);
    }
    private Task LoadAndCreateRawImage(string imageUrl,GameObject prefab)
    {
        GameObject imageGO = Instantiate(prefab, contentTransform);
        Button image = imageGO.GetComponent<Button>();
        //imageGO.SetActive(false);

        loaderImage.AssignImage(imageUrl, image, (texture) =>
        {

        });
        return Task.CompletedTask;
    }
}
