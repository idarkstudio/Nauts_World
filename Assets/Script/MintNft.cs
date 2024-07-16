using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintNft : MonoBehaviour
{
    public void OpenWebPage()
    {
        string url = "https://mxan6-xyaaa-aaaam-ab64q-cai.icp0.io/marketplace";// o https://yumi.io
        Application.OpenURL(url);
    }

    public void WalletPage()
    {
        string url = "https://mxan6-xyaaa-aaaam-ab64q-cai.icp0.io/wallet";// o https://yumi.io
        Application.OpenURL(url);
    }
}
