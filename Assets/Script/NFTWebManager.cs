using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class NFTWebManager : MonoBehaviour
{
    public static NFTWebManager Instance;

    public NFTData[] myNFT { get; private set; }
    public StakNFTData[] myStakedNFT { get; private set; }

    public void CallbackUserNfts(string json)
    {
        myNFT = JsonConvert.DeserializeObject<NFTData[]>(json);
    }

    public void CallbackUserStakes(string json)
    {
        myStakedNFT = JsonConvert.DeserializeObject<StakNFTData[]>(json);
    }
}

public class NFTData
{
    public string collection; // string
    public int id; // entero
    public string name; // string
    public string symbol; // string
    public string description; // string
    public string thumbnail; // string (img en base64)
    public string owner; // string
}

public class StakNFTData
{
    public string owner; // string
    public string collection; // string
    public int tokenId; // entero
    public int stakedAt; // entero (timestamp que representa la fecha de cuando se comenzo a stakear)
    public string name; // string
    public string symbol; // string
    public string description; // string
    public string thumbnail; // string (img en base64)
    public int maxSupply; // entero
}
