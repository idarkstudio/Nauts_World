using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class nftManager : MonoBehaviour
{
    public static nftManager Instance;
    public List<NftDelails> collection;
    [SerializeField] public ScrollViewManager managerScrollView;
    //[SerializeField] Text labelError;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        this.PedirNFTS();
    }

    public void RequestNFT(string json)
    {
        Debug.Log("REQUEST NFT");
        Debug.Log(json);
        if (json != null)
        {
            Debug.LogError("Paso null");
            List<NftDelails> nftList = JsonConvert.DeserializeObject<List<NftDelails>>(json);

            if (nftList == null)
            {
                Debug.LogError("Error en la deserealizacion de la collecion");
            }
            else
            {
                if (nftList.Count > 0)
                {
                    Debug.Log($"cantidad nfts devueltos {nftList.Count}" );
                    foreach (var nft in nftList)
                    {                      
                        if(nft.isOwner)
                            nft.ToString();
                    }
                    
                    this.collection = nftList;
                    this.collection.OrderByDescending(item => item.isOwner).ToList();
                    Debug.Log(collection);
                    managerScrollView.AsignarImagenes(this.collection);
                }
                else 
                {
                    Debug.Log("No hay nfts");
                   //this.labelError.text = "No hay NFTS";
                }
            }
        }
        else
        {
            Debug.LogError("Error en la deserealizacion de la collecion");
        }
    }
    public void PedirNFTS()
    {
        Debug.Log("Pidiendo NFTS...");
        ReacFunctions.GetNFT();
    }

    
}

