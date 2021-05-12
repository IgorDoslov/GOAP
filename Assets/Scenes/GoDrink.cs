using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoDrink : Action
{
     // called at the begining of this action
    public override bool OnActionEnter()
    {
        return true;

    }

    // On exiting the state
    public override bool OnActionExit()
    {
        GetComponent<Enemy>().thirstTimer = 0;
        internalState.RemoveState("Thirsty");
        internalState.ModifyInternalState("SatisfyThirst");
        return true;
    }
}
