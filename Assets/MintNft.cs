using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintNft : MonoBehaviour
{
    public void OpenWebPage()
    {
        string url = "https://yumi.io/market/d26yv-eqaaa-aaaah-abz4q-cai";// o https://yumi.io
        Application.OpenURL(url);
    }
}
