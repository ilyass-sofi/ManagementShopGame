using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDrawer : MonoBehaviour {

    public static InventoryDrawer inventoryDrawer;

    [SerializeField] private GameObject inventoryGrid;
    private GameObject itemInventory;

    void Awake ()
    {
        if (inventoryDrawer != null)
            Destroy(inventoryDrawer);
        else
            inventoryDrawer = this;

        DontDestroyOnLoad(this);


        itemInventory = Resources.Load("ItemInventory") as GameObject;
    }

    private void Start()
    {
        DisplayItems();

    }

    public void DisplayItems()
    {
        foreach (Transform child in inventoryGrid.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (KeyValuePair<Craftable, int> pair in Inventory.inventory.inventorySlots)
        {
            DisplayItem(pair.Key,pair.Value);
        }
    }

    public void DisplayItem(Craftable item, int quantity)
    {
        GameObject itemCreated = Instantiate(itemInventory, inventoryGrid.transform);
        //Setting sprite
        itemCreated.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item.Sprite;
        //Setting rarity
        itemCreated.transform.GetChild(0).GetComponent<Image>().color = ItemDrawer.itemDrawer.rarityColors[ItemDrawer.itemDrawer.GetColorNumber(item)];
        //Setting name
        itemCreated.transform.GetChild(1).GetComponent<Text>().text = quantity+"";
    }

   

}
