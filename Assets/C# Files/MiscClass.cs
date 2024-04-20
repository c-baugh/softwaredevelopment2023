using System.Collections;

using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Misc")]
public class MiscClass : ItemClass
{
    //data specific to the misc class 

    public override void Use(PlayerController Caller) { }
    
    public override MiscClass GetMisc() { return this; }
   
}
