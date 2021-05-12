using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoRegister : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        internalState.ModifyState("atHospital", 0);
        return true;
    }
}
