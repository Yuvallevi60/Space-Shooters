using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "ScriptableObjects/LootTable", order = 1)]
public class LootTable : ScriptableObject
{
    public List<DropItem> DropItems;
}

[System.Serializable]
public class DropItem
{
    public GameObject Prefab;
    public float DropRate; // This represents the individual drop chance for this item
}
