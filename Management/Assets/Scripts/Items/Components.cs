using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Components
{
    public int amount = 1;
    public BasicMaterial type;
    public enum BasicMaterial
    {
        Wood,
        Iron,
        Bronze,
        Gold
        
    };

   
	
}
