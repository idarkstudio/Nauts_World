using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaControler : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup canvasGroup;

    public void SetCanvasInteractable(bool interactable)
    {
        canvasGroup.interactable = interactable;
        canvasGroup.blocksRaycasts = interactable;
    }
}
