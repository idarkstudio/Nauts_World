using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    public UserNameData UserNameData;
    public TMP_InputField usernameField;

    public GameObject errorPopUp;
    public GameObject confirmPopUp;
    public TMP_Text confirmPopUpText;

    public void UpdateUserName(string usernameJson)
    {
        UserNameData = JsonConvert.DeserializeObject<UserNameData>(usernameJson);
        usernameField.text = UserNameData.userName;
    }
    
    public void OpenErrorButton()
    {
        errorPopUp.SetActive(true);

        LeanTween.alphaCanvas(errorPopUp.GetComponent<CanvasGroup>(), 1, 0.2f).setOnComplete(() =>
        {
            errorPopUp.GetComponent<CanvasGroup>().interactable = true;
            errorPopUp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            
        });
    }

    public void CloseErrorButton()
    {
        LeanTween.alphaCanvas(errorPopUp.GetComponent<CanvasGroup>(), 0, 0.2f).setOnComplete(()=>
        {
            errorPopUp.GetComponent<CanvasGroup>().interactable = false;
            errorPopUp.GetComponent<CanvasGroup>().blocksRaycasts = false;
            errorPopUp.SetActive(false);
        });
    }

    public void OpenConfirmButton(string newName)
    {
        confirmPopUp.SetActive(true);
        confirmPopUpText.text = newName;

        LeanTween.alphaCanvas(confirmPopUp.GetComponent<CanvasGroup>(), 1, 0.2f).setOnComplete(() =>
        {
            confirmPopUp.GetComponent<CanvasGroup>().interactable = true;
            confirmPopUp.GetComponent<CanvasGroup>().blocksRaycasts = true;

        });
    }


    public void CloseConfirmButtonChangingName()
    {
        LeanTween.alphaCanvas(confirmPopUp.GetComponent<CanvasGroup>(), 0, 0.2f).setOnComplete(() =>
        {
            confirmPopUp.GetComponent<CanvasGroup>().interactable = false;
            confirmPopUp.GetComponent<CanvasGroup>().blocksRaycasts = false;
            confirmPopUp.SetActive(false);
        });


        if (UserNameData == null)
        {
            UserNameData = new UserNameData();
        }

        UserNameData.userName = usernameField.text;
        UserNameData.principal = LoginManager.Instance.principal;

        ReacFunctions.SetUserName(JsonConvert.SerializeObject(UserNameData));
    }
    
    public void CloseConfirmButtonReturnNormal()
    {
        LeanTween.alphaCanvas(confirmPopUp.GetComponent<CanvasGroup>(), 0, 0.2f).setOnComplete(() =>
        {
            confirmPopUp.GetComponent<CanvasGroup>().interactable = false;
            confirmPopUp.GetComponent<CanvasGroup>().blocksRaycasts = false;
            confirmPopUp.SetActive(false);
        });
    }

    public void ChangeUserName()
    {
        if (usernameField.text.Length < 4)
            OpenErrorButton();
        else
            OpenConfirmButton(usernameField.text);
    }
}

public class UserNameData
{
    public string userName;
    public string principal;
}
