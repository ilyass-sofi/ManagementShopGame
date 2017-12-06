using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrawer : MonoBehaviour
{

    public static ItemDrawer itemDrawer;


    public Color[] rarityColors;
    [SerializeField] private GameObject grid;

    private BasicMaterial[] components;

    private GameObject itemPrefab;
    private GameObject compPrefab;

    private Craftable[] items;

    void Awake ()
    {

        if (itemDrawer != null)
            Destroy(itemDrawer);
        else
            itemDrawer = this;

        DontDestroyOnLoad(this);

        itemPrefab = Resources.Load("Item") as GameObject;
        compPrefab = Resources.Load("Comp") as GameObject;

        items = Resources.LoadAll("Items", typeof(Craftable)).Cast<Craftable>().ToArray();
        components = Resources.LoadAll("Components", typeof(BasicMaterial)).Cast<BasicMaterial>().ToArray();
    }
	
	void Start ()
    {
        CreateItems(items);
    }

    public void CreateItems(Craftable[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            CreateItem(items[i]);
        }
    }

    public void CreateItem(Craftable item)
    {   
        //Creating item container
        GameObject itemCreated = Instantiate(itemPrefab, grid.transform);
        //Setting name
        itemCreated.transform.GetChild(1).GetComponent<Text>().text = item.ItemName;
        //Setting rarity color
        itemCreated.transform.GetChild(0).GetComponent<Image>().color = rarityColors[GetColorNumber(item)];
        //Setting sprite
        itemCreated.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item.Sprite;
        //Setting price
        itemCreated.transform.GetChild(3).GetComponent<Text>().text = item.Price+"";
        //Setting components
        for (int i = 0; i < item.comps.Length; i++)
        {
            GameObject itemComp = Instantiate(compPrefab, itemCreated.transform.GetChild(2));
            itemComp.transform.GetChild(0).GetComponent<Image>().sprite = GetComponentSprite(item.comps[i].type);
            itemComp.transform.GetChild(1).GetComponent<Text>().text = "x" + item.comps[i].amount + "";
        }
        //Setting button
        itemCreated.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate { Inventory.inventory.BuildItem(item); });

    }

    public int GetColorNumber(Craftable item)
    {
        int colorNumber = -1;
        switch (item.GetRarity())
        {
            case Craftable.itemRarity.Common:
                colorNumber = 0;
                break;
            case Craftable.itemRarity.UnCommon:
                colorNumber = 1;
                break;
            case Craftable.itemRarity.Rare:
                colorNumber = 2;
                break;
            case Craftable.itemRarity.Epic:
                colorNumber = 3;
                break;
            case Craftable.itemRarity.Legendary:
                colorNumber = 4;
                break;
            default:
                break;
        }
        return colorNumber;
    }

    public Sprite GetComponentSprite(Components.BasicMaterial typeComp)
    {
        Sprite compSprite = null;
        switch (typeComp)
        {
            case Components.BasicMaterial.Wood:
                compSprite = components[0].Sprite;
                break;
            case Components.BasicMaterial.Iron:
                compSprite = components[1].Sprite;
                break;
            case Components.BasicMaterial.Bronze:
                compSprite = components[2].Sprite;
                break;
            case Components.BasicMaterial.Gold:
                compSprite = components[3].Sprite;
                break;
            default:
                break;
        }
        return compSprite;
    }
}
