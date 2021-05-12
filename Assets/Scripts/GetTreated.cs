﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GetTreated : Action
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
        World.Instance.GetStateCollection().ModifyState("Treated", 1);
        internalState.ModifyState("isCured", 1);
        inventory.RemoveItem(target);
        return true;
    }
}
