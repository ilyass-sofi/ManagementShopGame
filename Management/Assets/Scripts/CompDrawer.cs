using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CompDrawer : MonoBehaviour
{   

    [SerializeField] private GameObject topBar;
    private GameObject compPrefab;
    private BasicMaterial[] components;

    void Awake ()
    {
        compPrefab = Resources.Load("Comp") as GameObject;
        components = Resources.LoadAll("Components", typeof(BasicMaterial)).Cast<BasicMaterial>().ToArray();
       
       
    }

    private void Start()
    {
        DisplayComps();
    }

    public void DisplayComps()
    {
        int counter = 0;
        foreach (KeyValuePair<Components.BasicMaterial, int> pair in Inventory.inventory.compInventory)
        {
            DisplayComp(pair.Key, counter);
            counter++;
        }
    }

    public void DisplayComp(Components.BasicMaterial mat, int counter)
    {
        GameObject itemComp = Instantiate(compPrefab, topBar.transform);
        itemComp.transform.GetChild(0).GetComponent<Image>().sprite = components[counter].Sprite;
        itemComp.transform.GetChild(1).GetComponent<Text>().text = "x" + Inventory.inventory.compInventory[mat] + "";
    }

	
}
