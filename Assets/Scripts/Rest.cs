using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Rest : Action
{
    public override bool OnActionEnter()
    {
        return true;
    }

    public override bool OnActionExit()
    {
        internalState.RemoveState("exhausted");
        return true;
    }
}
