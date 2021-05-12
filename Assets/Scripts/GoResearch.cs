using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoResearch : Action
{
    public override bool OnActionEnter()
    {
        target = World.Instance.GetQueue("Office").RemoveResource();
        if (target == null)
            return false;
        inventory.AddItem(target);
        World.Instance.GetStateCollection().ModifyState("FreeOffice", -1);
        return true;
    }

    public override bool OnActionExit()
    {
        World.Instance.GetQueue("Office").AddResource(target);
        inventory.RemoveItem(target);
        World.Instance.GetStateCollection().ModifyState("FreeOffice", 1);
        return true;
    }
}
