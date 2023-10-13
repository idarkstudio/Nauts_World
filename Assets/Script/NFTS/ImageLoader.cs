using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System;

public class ImageLoader : MonoBehaviour
{
    public void AssignImage(string url, Image component, Action<Sprite> callback)
    {
        StartCoroutine(DownloadImage(url, component, callback));
    }

    private IEnumerator DownloadImage(string url, Image component, Action<Sprite> callback)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
            // aca ahay que catchear el error si viene un gift y no una imagen
            callback(null); // Llama al callback con nulo en caso de error.
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            component.sprite = sprite;
            callback(sprite); // Llama al callback con el sprite creado a partir de la textura cargada.
        }
    }
}
