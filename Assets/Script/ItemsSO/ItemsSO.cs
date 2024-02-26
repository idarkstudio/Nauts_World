using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class ItemsSO : ScriptableObject
{
    public Sprite icon;
    public int id;
    public GameObject itemInWorld;
}