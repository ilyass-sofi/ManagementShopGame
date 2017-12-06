using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{

    [SerializeField] private string itemName;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    [SerializeField] private int price;

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    [SerializeField] private Sprite sprite;

    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }


}
