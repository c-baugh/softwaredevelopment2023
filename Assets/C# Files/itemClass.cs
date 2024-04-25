using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : ScriptableObject
{
    [Header("Item")] //data shared across all item
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable = true;

    public virtual void Use(PlayerController Caller)
    {
        Debug.Log("Used item");
    }    
    public virtual ItemClass GetItem() { return this; }
    public virtual ToolClass GetTool() { return null; } 
    public virtual MiscClass GetMisc() { return null; }    
    public virtual ConsumableClass GetConsumable() { return null; }

}