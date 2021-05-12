using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoToCubicle : Action
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.GetStateCollection().ModifyState("TreatingPatient", 1);
        World.Instance.GetQueue("Cubicle").AddResource(target);
        inventory.RemoveItem(target);
        World.Instance.GetStateCollection().ModifyState("FreeCubicle", 1);
        return true;
    }
}
