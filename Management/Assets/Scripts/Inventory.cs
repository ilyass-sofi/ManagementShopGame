using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static Inventory inventory;

    [SerializeField] private Text goldText;

    private int gold;

    public int Gold
    {
        get { return gold; }
        set {
            gold = value;
            goldText.text = gold+"";
            }
    }


    public Dictionary<Craftable, int> inventorySlots = new Dictionary<Craftable, int>();
    public Dictionary<Components.BasicMaterial, int> compInventory = new Dictionary<Components.BasicMaterial, int>();

    void Awake()
    {
        if (inventory != null)
            Destroy(inventory);
        else
            inventory = this;

        DontDestroyOnLoad(this);


       

    }

    private void Start()
    {
        Gold = 1000;

        for (int i = 0; i < MaterialCraft.matCraft.BasicMaterials.Length; i++)
        {
            compInventory.Add(MaterialCraft.matCraft.BasicMaterials[i], 0);
        }

        
    }

    public void BuildItem(Craftable item)
    {   
        if(Gold >= item.Price && CheckStockComps(item))
        {
            Gold -= item.Price;

            for (int i = 0; i < item.comps.Length; i++)
            {
                compInventory[item.comps[i].type] -= item.comps[i].amount;
            }


            if (!inventorySlots.ContainsKey(item))
                inventorySlots.Add(item, 1);
            else inventorySlots[item]++;

            InventoryDrawer.inventoryDrawer.DisplayItems();
            CompDrawer.compDrawer.DisplayComps();
        }

    }

    public void CraftMaterial(Components.BasicMaterial mat)
    {
        compInventory[mat]++;
        CompDrawer.compDrawer.DisplayComps();
    }

    public bool CheckStockComps(Craftable item)
    {
        bool stockAvailable = true;

        for (int i = 0; i < item.comps.Length; i++)
        {
            if(compInventory[item.comps[i].type] < item.comps[i].amount)
            {
                stockAvailable = false;
                break;
            }
        }
        return stockAvailable;
    }

  
}
