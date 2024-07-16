using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDetaillerCollectionSetter : MonoBehaviour
{
    [SerializeField] private Image nautsPhoto;
    [SerializeField] private string nameNauts;
    [SerializeField] private string collectionText;
    [SerializeField] private string descriptionText;

    Sprite nautSavedPhoto;
    
    
    [SerializeField] private Image nautsDetailledPhoto;
    [SerializeField] private TMP_Text nameNautsDetailled;
    [SerializeField] private TMP_Text collectionTextDetailled;
    [SerializeField] private TMP_Text descriptionTextDetailled;



    public void SetterProfileFromLap(NFTData playerToSet)
    {
        byte[] imageBytes = Base64ToByteArray(playerToSet.thumbnail);
        Texture2D texture = ByteArrayToTexture2D(imageBytes);
        Sprite sprite = Texture2DToSprite(texture);

        nautSavedPhoto = sprite;

        nautsPhoto.sprite = nautSavedPhoto;
        nameNauts = playerToSet.name;
        collectionText = playerToSet.collection;
        descriptionText = playerToSet.description;
    }

    public void SetAllInfo()
    {
        nautsDetailledPhoto.sprite = nautSavedPhoto;
        nameNautsDetailled.text = nameNauts;
        collectionTextDetailled.text = collectionText;
        descriptionTextDetailled.text = descriptionText;
    }

    #region Deconvert Image
    public byte[] Base64ToByteArray(string base64String)
    {
        return System.Convert.FromBase64String(base64String);
    }

    public Texture2D ByteArrayToTexture2D(byte[] byteArray)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(byteArray); // Automatically resizes the texture dimensions
        return texture;
    }

    public Sprite Texture2DToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
    #endregion
}
