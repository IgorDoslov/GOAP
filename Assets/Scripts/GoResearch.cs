﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoResearch : Action
{
    public override bool PrePerform()
    {
        target = World.Instance.RemoveOffice();
        if (target == null)
            return false;
        inventory.AddItem(target);
        World.Instance.GetWorld().ModifyState("FreeOffice", -1);
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.AddOffice(target);
        inventory.RemoveItem(target);
        World.Instance.GetWorld().ModifyState("FreeOffice", 1);
        return true;
    }
}
