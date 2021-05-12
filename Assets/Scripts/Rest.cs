using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Rest : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        internalState.RemoveState("exhausted");
        return true;
    }
}
