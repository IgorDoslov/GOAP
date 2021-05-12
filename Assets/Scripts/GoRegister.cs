using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoRegister : Action
{
    public override bool OnActionEnter()
    {
        return true;
    }

    public override bool OnActionExit()
    {
        internalState.ModifyState("atHospital", 0);
        return true;
    }
}
