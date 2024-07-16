using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    public UserNameData UserNameData;
    public TMP_InputField usernameField;

    public void UpdateUserName(string usernameJson)
    {
        UserNameData = JsonConvert.DeserializeObject<UserNameData>(usernameJson);
        usernameField.text = UserNameData.userName;
    }
    
    public void ChangeUserName()
    {
        if (usernameField.text.Length < 4) return;

        if (UserNameData == null)
        {
            UserNameData = new UserNameData();
        }

        UserNameData.userName = usernameField.text;
        UserNameData.principal = LoginManager.Instance.principal;
        
        ReacFunctions.SetUserName(JsonConvert.SerializeObject(UserNameData));
    }
}

public class UserNameData
{
    public string userName;
    public string principal;
}
