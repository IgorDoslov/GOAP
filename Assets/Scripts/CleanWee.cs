using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class CleanWee : Action
{
    public override bool OnActionEnter()
    {
        target = World.Instance.GetQueue("Wee").RemoveResource();
        if (target == null)
        {
            return false;
        }
        inventory.AddItem(target);
        World.Instance.GetStateCollection().ModifyState("FreeWee", -1);
        return true;
    }

    public override bool OnActionExit()
    {
        inventory.RemoveItem(target);
        Destroy(target);
        return true;
    }
}
