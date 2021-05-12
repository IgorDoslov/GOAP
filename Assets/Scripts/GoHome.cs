using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoHome : Action
{
    public override bool OnActionEnter()
    {
        internalState.RemoveState("atHospital");

        return true;
    }

    public override bool OnActionExit()
    {
        Destroy(this.gameObject, 1);
        return true;
    }
}
