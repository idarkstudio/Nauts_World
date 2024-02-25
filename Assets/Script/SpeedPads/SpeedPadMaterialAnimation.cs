using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPadMaterialAnimation : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float scrollSpeedMultiplier;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = ((Time.time + scrollSpeed) * scrollSpeedMultiplier) * (-1);
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
