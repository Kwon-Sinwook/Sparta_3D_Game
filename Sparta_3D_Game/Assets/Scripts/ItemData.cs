using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "New ItemData")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public string ItemDescription;
}
