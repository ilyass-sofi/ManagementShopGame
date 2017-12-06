using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Craftable", fileName = "Craftable File Name")]
public class Craftable : Item
{
    public enum itemRarity
    {
        Common,
        UnCommon,
        Rare,
        Epic,
        Legendary
    };

    [SerializeField] private itemRarity rarity;

    public itemRarity GetRarity()
    {
        return rarity;
    }

    public Components[] comps;
   
}
