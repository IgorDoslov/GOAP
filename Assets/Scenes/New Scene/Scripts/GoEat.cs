using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoEat : Action
{
     // called at the begining of this action
    public override bool OnActionEnter()
    {
        
        return true;

    }

    // On exiting the state
    public override bool OnActionExit()
    {
        GetComponent<Enemy>().hungerTimer = 0;
        internalState.RemoveState("Hungry");
        internalState.ModifyInternalState("SatisfyHunger");

        return true;
    }
}
