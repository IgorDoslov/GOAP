﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoToToilet : Action
{
    public override bool PrePerform()
    {
        target = World.Instance.GetQueue("Toilet").RemoveResource();
        if (target == null)
            return false;
        inventory.AddItem(target);
        World.Instance.GetWorld().ModifyState("FreeToilet", -1);
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.GetQueue("Toilet").AddResource(target);
        inventory.RemoveItem(target);
        World.Instance.GetWorld().ModifyState("FreeToilet", 1);
        beliefs.RemoveState("busting");
        return true;
    }
}
