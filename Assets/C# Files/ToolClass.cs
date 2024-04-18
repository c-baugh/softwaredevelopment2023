using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName ="Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")] //data specific to tool class
    public Tooltype toolType;
    public enum Tooltype
    {
        weapon, 
        pickaxe, 
        hammer,
        axe
    }
    public override  ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }
    public override MiscClass GetMisc() { return null; } 
    public override ConsumableClass GetConsumable() { return null; }

}
