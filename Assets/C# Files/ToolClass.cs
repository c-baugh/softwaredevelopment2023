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

    public override void Use(PlayerController Caller)
    {
        base.Use(Caller);
        Debug.Log("Swing Tool");
    }

    public override ToolClass GetTool() { return this; }
    

}
