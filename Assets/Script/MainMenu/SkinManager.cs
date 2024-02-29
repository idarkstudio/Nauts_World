using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
   [SerializeField] private Button _luckyButton;
   
   private void Awake()
   {
      UnlockNFT();
   }

   private void UnlockNFT()
   {
      if (nftManager.Instance.collection.Any(x=>x.name.Contains("Lucky")))
      {
         _luckyButton.interactable = true;
      }
   }
}