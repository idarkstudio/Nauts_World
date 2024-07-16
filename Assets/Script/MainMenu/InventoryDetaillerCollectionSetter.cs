using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        string cleanedBase64String = CleanBase64String(playerToSet.thumbnail);
        byte[] imageBytes = Base64ToByteArray(cleanedBase64String);
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
    
    public string CleanBase64String(string base64)
    {
        // Remove data URI scheme if present
        string base64WithoutPrefix = Regex.Replace(base64, "^data:image\\/[a-zA-Z]+;base64,", string.Empty);
        // Replace URL-safe characters
        string base64Standardized = base64WithoutPrefix.Replace('-', '+').Replace('_', '/');
        // Remove any whitespace
        string base64Trimmed = base64Standardized.Trim();

        return base64Trimmed;
    }
    
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
