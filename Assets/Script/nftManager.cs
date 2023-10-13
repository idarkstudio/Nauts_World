using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class nftManager : MonoBehaviour
{
    public static nftManager Instance;
    public Button Boton;
    public List<NftDelails> collection;
    [SerializeField] public ScrollViewManager managerScrollView;
    private bool TieneNFTS = false;

    private void Awake()
    {
        Instance = this;
    }
    public void RequestNFT(string json)
    {
        if (json != null)
        {
            List<NftDelails> nftList = JsonConvert.DeserializeObject<List<NftDelails>>(json);

            if (nftList == null)
            {
                Debug.LogError("Error en la deserealizacion de la collecion");
            }
            else
            {
                foreach (var nft in nftList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"nombre: {nft.name}");
                    sb.AppendLine($"descripcion: {nft.description}");
                    sb.AppendLine($"imagen: {nft.image}");
                    sb.AppendLine($"collection :{nft.collection}");
                    Debug.Log(sb.ToString());
                }

                collection = nftList;
                Debug.Log(collection);
                //managerScrollView.AsignarImagenes(this.collection);
                TieneNFTS = true;
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

