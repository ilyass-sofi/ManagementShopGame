using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDrawer : MonoBehaviour
{

    [SerializeField] private GameObject materialsGrid;
    private GameObject matPrefab;

    private void Awake()
    {
        matPrefab = Resources.Load("MaterialItem") as GameObject;
    }

    void Start ()
    {
        DrawMaterialsCraft();

    }

    public void DrawMaterialsCraft()
    {
        for (int i = 0; i < CompDrawer.compDrawer.Components.Length; i++)
        {
            DrawMaterialCraft(CompDrawer.compDrawer.Components[i]);
        }
    }

    public void DrawMaterialCraft(BasicMaterial basicMaterial)
    {
        GameObject itemCreated = Instantiate(matPrefab, materialsGrid.transform);
        //Setting sprite
        itemCreated.transform.GetChild(1).GetComponent<Image>().sprite = basicMaterial.Sprite;
        //Setting name
        itemCreated.transform.GetChild(2).GetComponent<Text>().text = basicMaterial.ItemName;
        //Setting price
        itemCreated.transform.GetChild(3).GetComponent<Text>().text = basicMaterial.upgradeBasicPrice +"";
    }
	

}
