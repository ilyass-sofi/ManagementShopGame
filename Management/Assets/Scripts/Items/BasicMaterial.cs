using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Basic Material", fileName = "Basic Material File Name")]
public class BasicMaterial : Item
{
    public int upgradeBasicPrice;

    private int upgradeCurrentPrice;

    public float upgradeMultiplicator;

    public float timePerUnit;
}
