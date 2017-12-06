using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    public static Inventory inventory;

    

    public Dictionary<Craftable, int> inventorySlots = new Dictionary<Craftable, int>();
    public Dictionary<Components.BasicMaterial, int> compInventory = new Dictionary<Components.BasicMaterial, int>();

    void Awake()
    {
        if (inventory != null)
            Destroy(inventory);
        else
            inventory = this;

        DontDestroyOnLoad(this);

        compInventory.Add(Components.BasicMaterial.Wood, 1);
        compInventory.Add(Components.BasicMaterial.Iron, 5);
        compInventory.Add(Components.BasicMaterial.Gold, 1);

       

    }

    public void BuildItem(Craftable item)
    {
        if (!inventorySlots.ContainsKey(item))
            inventorySlots.Add(item, 1);
        else inventorySlots[item]++;

        InventoryDrawer.inventoryDrawer.DisplayItems();
    }
}
