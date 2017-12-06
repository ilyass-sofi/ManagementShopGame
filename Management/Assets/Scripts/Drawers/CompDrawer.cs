using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CompDrawer : MonoBehaviour
{

    public static CompDrawer compDrawer;


    [SerializeField] private GameObject topBar;
    private GameObject compPrefab;
    private BasicMaterial[] components;

    public BasicMaterial[] Components
    {
        get { return components; }
        set { components = value;}
    }

    void Awake ()
    {

        if (compDrawer != null)
            Destroy(compDrawer);
        else
            compDrawer = this;

        DontDestroyOnLoad(this);


        compPrefab = Resources.Load("Comp") as GameObject;
        components = Resources.LoadAll("Components", typeof(BasicMaterial)).Cast<BasicMaterial>().ToArray();
    }

    private void Start()
    {
        DisplayComps();
    }

    public void DisplayComps()
    {
        foreach (Transform child in topBar.transform)
        {
            Destroy(child.gameObject);
        }

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
