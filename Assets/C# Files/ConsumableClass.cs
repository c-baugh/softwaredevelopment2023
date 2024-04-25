using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    [Header("Consumable")] //data specific to consumable class
    public float healthAdded;

    public override void Use(PlayerController caller)
    {
        base.Use(caller);
        Debug.Log("Eat Consumable");
        caller.inventory.UseSelected();
    }

    public override ConsumableClass GetConsumable() { return this; }


}


